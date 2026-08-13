using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Attendances;

public class ViewAttendanceUseCase(IAttendanceRepository attendanceRepository) : IViewAttendanceUseCase
{
    public async Task<IEnumerable<Attendance>> GetAttendances()
    {
        return await attendanceRepository.GetAttendances();
    }
}