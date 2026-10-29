
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class LessonsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : ILessonsRepository
{
    public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var existing = await db.Lessons.FindAsync(lesson.LessonId);
        if (existing != null)
        {
            existing.Status = lesson.Status;
            existing.IsPaid = lesson.IsPaid;
            existing.StartTime = lesson.StartTime;
            existing.EndTime = lesson.EndTime;
            existing.Duration = lesson.Duration;
            if (lesson.GroupId > 0) existing.GroupId = lesson.GroupId;
            if (lesson.TeacherId > 0) existing.TeacherId = lesson.TeacherId;
            await db.SaveChangesAsync();
            return existing;
        }
        return lesson;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        var lessons = await db.Lessons
            .Include(l => l.Group)
                .ThenInclude(g => g.Students)
                    .ThenInclude(s => s.Contract)
            .Include(l => l.Teacher)
            .Include(l => l.Students)
            .Include(l => l.Attendances!)
                .ThenInclude(a => a.Student)
            .ToListAsync();

        var hasChanges = false;
        foreach (var lesson in lessons)
        {
            if (lesson.Status == LessonStatus.Scheduled && lesson.Group != null)
            {
                var group = lesson.Group;

                // Sync Teacher
                if (lesson.TeacherId != group.TeacherId)
                {
                    lesson.TeacherId = group.TeacherId;
                    if (lesson.Attendances != null)
                    {
                        foreach (var attendance in lesson.Attendances)
                        {
                            attendance.TeacherId = group.TeacherId;
                        }
                    }
                    hasChanges = true;
                }

                // Sync StartTime & EndTime & Duration
                var correctStartTime = DateTime.SpecifyKind(lesson.StartTime.Date.Add(group.StartTime.ToTimeSpan()), DateTimeKind.Utc);
                var correctEndTime = DateTime.SpecifyKind(lesson.StartTime.Date.Add(group.EndTime.ToTimeSpan()), DateTimeKind.Utc);
                var correctDuration = correctEndTime - correctStartTime;

                if (lesson.StartTime != correctStartTime || lesson.EndTime != correctEndTime || lesson.Duration != correctDuration)
                {
                    lesson.StartTime = correctStartTime;
                    lesson.EndTime = correctEndTime;
                    lesson.Duration = correctDuration;
                    if (lesson.Attendances != null)
                    {
                        foreach (var attendance in lesson.Attendances)
                        {
                            attendance.Date = correctStartTime;
                        }
                    }
                    hasChanges = true;
                }

                // Sync Students and Attendances
                var groupQualifyingStudents = group.Students?
                    .Where(s => s.Contract != null && (s.Contract.HoursRemaining > 0 || s.Contract.GetHoursRemaining() >= -6))
                    .ToList() ?? [];

                var currentLessonStudents = lesson.Students?.ToList() ?? [];
                var currentAttendances = lesson.Attendances?.ToList() ?? [];

                var currentStudentIds = currentLessonStudents.Select(s => s.StudentId).ToHashSet();
                var groupStudentIds = groupQualifyingStudents.Select(s => s.StudentId).ToHashSet();

                var studentsToAdd = groupQualifyingStudents.Where(s => !currentStudentIds.Contains(s.StudentId)).ToList();
                var studentsToRemove = currentLessonStudents.Where(s => !groupStudentIds.Contains(s.StudentId)).ToList();

                if (studentsToAdd.Count > 0 || studentsToRemove.Count > 0)
                {
                    var updatedStudentList = currentLessonStudents.Where(s => groupStudentIds.Contains(s.StudentId)).ToList();
                    updatedStudentList.AddRange(studentsToAdd);
                    lesson.Students = updatedStudentList;

                    foreach (var student in studentsToAdd)
                    {
                        if (!currentAttendances.Any(a => a.StudentId == student.StudentId))
                        {
                            var attendance = new Attendance
                            {
                                StudentId = student.StudentId,
                                LessonId = lesson.LessonId,
                                TeacherId = lesson.TeacherId,
                                Date = lesson.StartTime,
                                AttendanceStatus = AttendanceStatus.Pending,
                                EngagementStatus = EngagmentStatus.NotEngaged
                            };
                            db.Attendances.Add(attendance);
                        }
                    }

                    foreach (var student in studentsToRemove)
                    {
                        var attToRemove = currentAttendances.Where(a => a.StudentId == student.StudentId && (a.AttendanceStatus == AttendanceStatus.Pending || a.AttendanceStatus == null)).ToList();
                        foreach (var att in attToRemove)
                        {
                            db.Attendances.Remove(att);
                        }
                    }

                    hasChanges = true;
                }
            }
        }

        if (hasChanges)
        {
            await db.SaveChangesAsync();
        }

        return lessons;
    }

    public async Task<bool> LessonExistsAsync(int groupId, DateTime date)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Lessons.AnyAsync(l => l.GroupId == groupId && l.StartTime == date);
    }

    public async Task AddLessonAsync(Lesson lesson)
    {
        await using var db = await _factory.CreateDbContextAsync();

        var students = lesson.Students?.ToList();
        lesson.Group = null;
        lesson.Teacher = null;
        lesson.Attendances = null;
        lesson.Students = null;

        db.Lessons.Add(lesson);
        await db.SaveChangesAsync();

        if (students != null && students.Count > 0)
        {
            var studentIds = students.Select(s => s.StudentId).ToList();
            var dbStudents = await db.Students.Where(s => studentIds.Contains(s.StudentId)).ToListAsync();
            lesson.Students = dbStudents;
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteLessonAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var lesson = await db.Lessons.FindAsync(id);
        if (lesson != null)
        {
            db.Lessons.Remove(lesson);
            await db.SaveChangesAsync();
        }
    }
}