using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class AttendanceEFCoreRepository : IAttendanceRepository
{
    public async Task<IEnumerable<Attendance>> GetAttendances()
    {
        throw new NotImplementedException();
    }

    public async Task GenerateAtendance(Attendance attendance)
    {
        throw new NotImplementedException();
    }

    public async Task<Attendance> UpdateAttendance(Attendance attendance)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}