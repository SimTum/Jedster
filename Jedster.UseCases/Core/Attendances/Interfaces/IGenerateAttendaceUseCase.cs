using Jedster.CoreBuisness;

namespace Jedster.UseCases.Attendances;

public interface IGenerateAttendaceUseCase
{
    Task ExecuteAsync(Attendance attendance);
}