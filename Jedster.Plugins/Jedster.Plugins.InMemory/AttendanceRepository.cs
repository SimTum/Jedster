using Jedster.CoreBuisness;
using Jedster.CoreBusiness;
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

        var oldStatus = index >= 0 ? _attendances[index].AttendanceStatus : AttendanceStatus.Pending;
        var newStatus = attendance.AttendanceStatus;

        if (index >= 0)
        {
            _attendances[index] = attendance;
        }
        else
        {
            _attendances.Add(attendance);
        }

        if (attendance.Lesson != null && attendance.Lesson.Status == LessonStatus.Scheduled)
        {
            attendance.Lesson.Status = LessonStatus.Completed;
        }

        if (attendance.Student?.Contract != null && oldStatus != newStatus)
        {
            var contract = attendance.Student.Contract;
            double duration = 0;
            if (attendance.Lesson != null)
            {
                if (attendance.Lesson.Duration.TotalHours > 0)
                    duration = attendance.Lesson.Duration.TotalHours;
                else if (attendance.Lesson.EndTime > attendance.Lesson.StartTime)
                    duration = (attendance.Lesson.EndTime - attendance.Lesson.StartTime).TotalHours;
                else if (attendance.Lesson.Group != null)
                    duration = (attendance.Lesson.Group.EndTime - attendance.Lesson.Group.StartTime).TotalHours;
            }
            if (duration <= 0) duration = 1.0;

            if (oldStatus == AttendanceStatus.Present)
            {
                contract.HoursCompleted -= duration;
                contract.HoursRemaining += duration;
            }
            else if (oldStatus == AttendanceStatus.Absent)
            {
                contract.HoursMissed -= duration;
                contract.HoursRemaining += duration;
            }

            if (newStatus == AttendanceStatus.Present)
            {
                contract.HoursRemaining -= duration;
                contract.HoursCompleted += duration;
            }
            else if (newStatus == AttendanceStatus.Absent)
            {
                contract.HoursRemaining -= duration;
                contract.HoursMissed += duration;
            }
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