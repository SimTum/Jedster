using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Attendances;

public class UpdateAttendanceUseCase(IAttendanceRepository attendanceRepository) : IUpdateAttendanceUseCase
{
    public async Task<Attendance> ExecuteAsync(Attendance attendance)
    {
        return await attendanceRepository.UpdateAttendance(attendance);
    }
}