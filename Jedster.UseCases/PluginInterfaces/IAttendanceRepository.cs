using Jedster.CoreBuisness;
using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAttendances();
    Task GenerateAtendance(Attendance attendance);
    Task<Attendance> UpdateAttendance(Attendance attendance);
}