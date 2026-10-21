using Jedster.CoreBuisness;
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
                existing.AttendanceStatus = attendance.AttendanceStatus;
                existing.EngagementStatus = attendance.EngagementStatus;
                existing.Date = attendance.Date;
                if (attendance.LessonId > 0) existing.LessonId = attendance.LessonId;
                if (attendance.StudentId > 0) existing.StudentId = attendance.StudentId;
                if (attendance.TeacherId > 0) existing.TeacherId = attendance.TeacherId;

                var lesson = await db.Lessons.FindAsync(existing.LessonId);
                if (lesson != null && lesson.Status == LessonStatus.Scheduled)
                {
                    lesson.Status = LessonStatus.Completed;
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