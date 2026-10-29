using Jedster.CoreBusiness;

namespace Jedster.UseCases.Attendances;

public interface IGenerateAttendaceUseCase
{
    Task ExecuteAsync(Attendance attendance);
}