using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Attendances;

public class AttendanceExistsUseCase(IAttendanceRepository attendanceRepository)
{
    public async Task<bool> ExecuteAsync(int lessonId, int studentId)
    {
        return await attendanceRepository.AttendanceExistsAsync(lessonId, studentId);
    }
}