
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class GroupsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IGroupRepository
{
    public async Task<IEnumerable<Group>> GetGroupsByNameAsync(string nome)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Groups?.Include(g => g.Teacher).Include(g => g.Students).ThenInclude(s => s.Contract).ToListAsync()!;
    }

    public async Task RegisterGroup(Group group)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Groups != null)
        {
            db.Groups.Add(group);
            // group.UpdateTeacherHours();
        }
        await db.SaveChangesAsync();
    }

    public async Task<Group?> GetGroupByIdAsync(int groupId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Groups.FindAsync(groupId) ?? null;
    }

    public async Task EditGroupAsync(Group group)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var _group = await db.Groups
            .Include(g => g.Students)
                .ThenInclude(s => s.Contract)
            .FirstOrDefaultAsync(g => g.GroupId == group.GroupId);

        if (_group != null)
        {
            _group.Name = group.Name;
            _group.StartTime = group.StartTime;
            _group.EndTime = group.EndTime;
            _group.TeacherId = group.TeacherId;
            _group.WeekDay = group.WeekDay;
            _group.NumberStudents = group.NumberStudents;

            var scheduledLessons = await db.Lessons
                .Include(l => l.Students)
                .Include(l => l.Attendances)
                .Where(l => l.GroupId == group.GroupId && l.Status == LessonStatus.Scheduled)
                .ToListAsync();

            var qualifyingStudents = _group.Students?
                .Where(s => s.Contract != null && (s.Contract.HoursRemaining > 0 || s.Contract.GetHoursRemaining() >= 0))
                .ToList() ?? [];
            var groupStudentIds = qualifyingStudents.Select(s => s.StudentId).ToHashSet();

            foreach (var lesson in scheduledLessons)
            {
                lesson.TeacherId = _group.TeacherId;
                var correctStartTime = DateTime.SpecifyKind(lesson.StartTime.Date.Add(_group.StartTime.ToTimeSpan()), DateTimeKind.Utc);
                var correctEndTime = DateTime.SpecifyKind(lesson.StartTime.Date.Add(_group.EndTime.ToTimeSpan()), DateTimeKind.Utc);
                lesson.StartTime = correctStartTime;
                lesson.EndTime = correctEndTime;
                lesson.Duration = correctEndTime - correctStartTime;

                if (lesson.Attendances != null)
                {
                    foreach (var attendance in lesson.Attendances)
                    {
                        attendance.TeacherId = _group.TeacherId;
                        attendance.Date = correctStartTime;
                        attendance.Lesson.StartTime = correctStartTime;
                        attendance.Lesson.EndTime = correctEndTime;
                        attendance.Lesson.Duration = correctEndTime - correctStartTime;
                    }
                }

                var currentLessonStudents = lesson.Students?.ToList() ?? [];
                var currentStudentIds = currentLessonStudents.Select(s => s.StudentId).ToHashSet();
                var currentAttendances = lesson.Attendances?.ToList() ?? [];

                var studentsToAdd = qualifyingStudents.Where(s => !currentStudentIds.Contains(s.StudentId)).ToList();
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
                }
            }

            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteGroupByIdAsync(int groupId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Groups?.Remove(await db.Groups.FindAsync(groupId) ?? throw new InvalidOperationException());
        await db.SaveChangesAsync();
        ;
    }
}