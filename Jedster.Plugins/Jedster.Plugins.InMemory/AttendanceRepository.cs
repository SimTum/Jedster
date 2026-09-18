using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly List<Attendance> _attendances = [];

    public Task<IEnumerable<Attendance>> GetAttendances()
    {
        return Task.FromResult<IEnumerable<Attendance>>(_attendances);
    }

    public Task GenerateAtendance(Attendance attendance)
    {
        _attendances.Add(attendance);
        return Task.CompletedTask;
    }

    public Task<Attendance> UpdateAttendance(Attendance attendance)
    {
        if (attendance is null) return Task.FromResult<Attendance>(null!);

        var index = _attendances.FindIndex(a => 
            (attendance.EntryId > 0 && a.EntryId == attendance.EntryId) || 
            (a.LessonId == attendance.LessonId && a.StudentId == attendance.StudentId));

        if (index >= 0)
        {
            _attendances[index] = attendance;
        }
        else
        {
            _attendances.Add(attendance);
        }
        return Task.FromResult(attendance);
    }

    public Task<IEnumerable<Attendance>> GenerateAtendanceFromSchedule(DateTime startTime, DateTime endTime)
    {
        var result = _attendances.Where(a => a.Date >= startTime && a.Date <= endTime);
        return Task.FromResult(result);
    }

    public Task<Attendance> AddAttendanceAsync(Attendance attendance)
    {
        if (attendance.EntryId <= 0)
        {
            var nextId = _attendances.Count > 0 ? _attendances.Max(a => a.EntryId) + 1 : 1;
            attendance.EntryId = nextId;
        }
        _attendances.Add(attendance);
        return Task.FromResult(attendance);
    }

    public Task<bool> AttendanceExistsAsync(int lessonId, int studentId)
    {
        return Task.FromResult(_attendances.Any(a => a.LessonId == lessonId && a.StudentId == studentId));
    }
}