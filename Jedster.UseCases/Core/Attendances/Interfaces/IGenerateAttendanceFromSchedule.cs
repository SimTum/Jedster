using Jedster.CoreBuisness;

namespace Jedster.UseCases.Attendances;

public interface IGenerateAttendanceFromSchedule
{
    Task<IEnumerable<Attendance>> ExecuteAsync(DateTime startTime, DateTime endTime);
}