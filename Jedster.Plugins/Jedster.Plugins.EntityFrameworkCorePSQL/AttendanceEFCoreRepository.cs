using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class AttendanceEFCoreRepository(IDbContextFactory<JedsterContext> _factory) : IAttendanceRepository
{
    public async Task<IEnumerable<Attendance>> GetAttendances()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Attendances.ToListAsync() ?? null;
    }

    public async Task GenerateAtendance(Attendance attendance)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Attendances.Add(attendance);
        await db.SaveChangesAsync();
    }

    public async Task<Attendance> UpdateAttendance(Attendance attendance)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (attendance is not null)
        {
        db.Attendances.Update(attendance);
        await db.SaveChangesAsync();
        return attendance;
        }
        return null;
    }

    public async Task<IEnumerable<Attendance>> GenerateAtendanceFromSchedule(DateTime startTime, DateTime endTime)
    {
        throw new NotImplementedException();
    }

    public async Task<Attendance> AddAttendanceAsync(Attendance attendance)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AttendanceExistsAsync(int lessonId, int studentId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return db.Attendances != null && await db.Attendances.AnyAsync(a => a.LessonId == lessonId && a.StudentId == studentId);
    }
}