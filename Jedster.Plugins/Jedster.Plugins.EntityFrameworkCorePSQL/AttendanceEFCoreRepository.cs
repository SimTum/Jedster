
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class AttendanceEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IAttendanceRepository
{
    public async Task<IEnumerable<Attendance>> GetAttendances()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Attendances
            .Include(a => a.Student)
                .ThenInclude(s => s.Contract)
            .Include(a => a.Teacher)
            .Include(a => a.Lesson)
                .ThenInclude(l => l.Group)
            .ToListAsync();
    }

    public async Task GenerateAtendance(Attendance attendance)
    {
        await using var db = await _factory.CreateDbContextAsync();
        attendance.Lesson = null!;
        attendance.Student = null!;
        attendance.Teacher = null!;
        db.Attendances.Add(attendance);
        await db.SaveChangesAsync();
    }

    public async Task<Attendance> UpdateAttendance(Attendance attendance)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (attendance is not null)
        {
            var existing = await db.Attendances.FindAsync(attendance.EntryId);
            if (existing == null && attendance.LessonId > 0 && attendance.StudentId > 0)
            {
                existing = await db.Attendances.FirstOrDefaultAsync(a => a.LessonId == attendance.LessonId && a.StudentId == attendance.StudentId);
            }

            if (existing != null)
            {
                var oldStatus = existing.AttendanceStatus;
                var newStatus = attendance.AttendanceStatus;

                existing.AttendanceStatus = attendance.AttendanceStatus;
                existing.EngagementStatus = attendance.EngagementStatus;
                existing.Date = attendance.Date;
                existing.Observations = attendance.Observations;
                if (attendance.LessonId > 0) existing.LessonId = attendance.LessonId;
                if (attendance.StudentId > 0) existing.StudentId = attendance.StudentId;
                if (attendance.TeacherId > 0) existing.TeacherId = attendance.TeacherId;

                var lesson = await db.Lessons.Include(l => l.Group).FirstOrDefaultAsync(l => l.LessonId == existing.LessonId);
                if (lesson != null && lesson.Status == LessonStatus.Scheduled)
                {
                    lesson.Status = LessonStatus.Completed;
                }

                if (oldStatus != newStatus && existing.StudentId > 0)
                {
                    var contract = await db.Contracts.FirstOrDefaultAsync(c => c.StudentId == existing.StudentId);
                    if (contract == null)
                    {
                        var student = await db.Students.Include(s => s.Contract).FirstOrDefaultAsync(s => s.StudentId == existing.StudentId);
                        contract = student?.Contract;
                    }

                    if (contract != null)
                    {
                        double duration = 0;
                        if (lesson != null)
                        {
                            if (lesson.Duration.TotalHours > 0)
                                duration = lesson.Duration.TotalHours;
                            else if (lesson.EndTime > lesson.StartTime)
                                duration = (lesson.EndTime - lesson.StartTime).TotalHours;
                            else if (lesson.Group != null)
                                duration = (lesson.Group.EndTime - lesson.Group.StartTime).TotalHours;
                        }

                        if (duration <= 0)
                        {
                            duration = 1.0;
                        }

                        // Revert old status
                        if (oldStatus == AttendanceStatus.Present)
                        {
                            contract.HoursCompleted -= duration;
                            contract.HoursRemaining += duration;
                        }
                        else if (oldStatus == AttendanceStatus.Absent)
                        {
                            contract.HoursMissed -= duration;
                            contract.HoursRemaining += duration;
                        }

                        // Apply new status
                        if (newStatus == AttendanceStatus.Present)
                        {
                            contract.HoursRemaining -= duration;
                            contract.HoursCompleted += duration;
                        }
                        else if (newStatus == AttendanceStatus.Absent)
                        {
                            contract.HoursRemaining -= duration;
                            contract.HoursMissed += duration;
                        }
                    }
                }

                await db.SaveChangesAsync();
                return existing;
            }
        }
        return null!;
    }

    public async Task<IEnumerable<Attendance>> GenerateAtendanceFromSchedule(DateTime startTime, DateTime endTime)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Attendances
            .Include(a => a.Student)
                .ThenInclude(s => s.Contract)
            .Include(a => a.Teacher)
            .Include(a => a.Lesson)
                .ThenInclude(l => l.Group)
            .Where(a => a.Date >= startTime && a.Date <= endTime)
            .ToListAsync();
    }

    public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Attendances != null)
        {
            attendance.Lesson = null!;
            attendance.Student = null!;
            attendance.Teacher = null!;
            db.Attendances.Add(attendance);

            if (attendance.AttendanceStatus == AttendanceStatus.Present || attendance.AttendanceStatus == AttendanceStatus.Absent)
            {
                var lesson = await db.Lessons.Include(l => l.Group).FirstOrDefaultAsync(l => l.LessonId == attendance.LessonId);
                var contract = await db.Contracts.FirstOrDefaultAsync(c => c.StudentId == attendance.StudentId);
                if (contract == null)
                {
                    var student = await db.Students.Include(s => s.Contract).FirstOrDefaultAsync(s => s.StudentId == attendance.StudentId);
                    contract = student?.Contract;
                }

                if (contract != null)
                {
                    double duration = 0;
                    if (lesson != null)
                    {
                        if (lesson.Duration.TotalHours > 0)
                            duration = lesson.Duration.TotalHours;
                        else if (lesson.EndTime > lesson.StartTime)
                            duration = (lesson.EndTime - lesson.StartTime).TotalHours;
                        else if (lesson.Group != null)
                            duration = (lesson.Group.EndTime - lesson.Group.StartTime).TotalHours;
                    }

                    if (duration <= 0)
                    {
                        duration = 1.0;
                    }

                    if (attendance.AttendanceStatus == AttendanceStatus.Present)
                    {
                        contract.HoursRemaining -= duration;
                        contract.HoursCompleted += duration;
                    }
                    else if (attendance.AttendanceStatus == AttendanceStatus.Absent)
                    {
                        contract.HoursRemaining -= duration;
                        contract.HoursMissed += duration;
                    }
                }
            }

            await db.SaveChangesAsync();
        }
        return attendance;
    }

    public async Task<bool> AttendanceExistsAsync(int lessonId, int studentId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return db.Attendances != null && await db.Attendances.AnyAsync(a => a.LessonId == lessonId && a.StudentId == studentId);
    }
}