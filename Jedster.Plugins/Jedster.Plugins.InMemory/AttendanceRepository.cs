using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class AttendanceRepository : IAttendanceRepository
{
    public Task<IEnumerable<Attendance>> GetAttendances()
    {
        throw new NotImplementedException();
    }

    public Task GenerateAtendance(Attendance attendance)
    {
        throw new NotImplementedException();
    }

    public Task<Attendance> UpdateAttendance(Attendance attendance)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Attendance>> GenerateAtendanceFromSchedule(DateTime startTime, DateTime endTime)
    {
        throw new NotImplementedException();
    }
}