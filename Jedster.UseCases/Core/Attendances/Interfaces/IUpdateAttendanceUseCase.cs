using Jedster.CoreBuisness;

namespace Jedster.UseCases.Attendances;

public interface IUpdateAttendanceUseCase
{
    Task<Attendance> ExecuteAsync(Attendance attendance);
}
