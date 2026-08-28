using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Attendances;

public class GenerateAttendanceFromSchedule(IAttendanceRepository attendanceRepository)
{
    public async Task<IEnumerable<Attendance>> ExecuteAsync(DateTime startTime, DateTime endTime)
    {
        return await attendanceRepository.GenerateAtendanceFromSchedule(startTime, endTime);
    }
}