using Jedster.CoreBusiness;

namespace Jedster.UseCases.Attendances;

public interface IUpdateAttendanceUseCase
{
    Task<Attendance> ExecuteAsync(Attendance attendance);
}
