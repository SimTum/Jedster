using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Attendances;

public class GenerateAttendaceUseCase(IAttendanceRepository attendanceRepository) : IGenerateAttendaceUseCase
{
    public async Task ExecuteAsync(Attendance attendance)
    {
        await attendanceRepository.GenerateAtendance(attendance);
    }
}