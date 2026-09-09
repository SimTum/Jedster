using Jedster.CoreBuisness;
using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface IAttendanceRepository
{
    Task<IEnumerable<Attendance>> GetAttendances();
    Task GenerateAtendance(Attendance attendance);
    Task<Attendance> UpdateAttendance(Attendance attendance);
    Task<IEnumerable<Attendance>> GenerateAtendanceFromSchedule(DateTime startTime, DateTime endTime);
    Task<Attendance> AddAttendanceAsync(Attendance attendance);
    Task<bool> AttendanceExistsAsync(int lessonId, int studentId);
}