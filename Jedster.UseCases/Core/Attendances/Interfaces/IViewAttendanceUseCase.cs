using Jedster.CoreBuisness;

namespace Jedster.UseCases.Attendances;

public interface IViewAttendanceUseCase
{
    Task<IEnumerable<Attendance>> GetAttendances();
}