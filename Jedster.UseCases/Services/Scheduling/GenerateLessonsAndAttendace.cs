using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.Scheduling;

public class GenerateLessonsAndAttendace(
    IGroupRepository groupRepository,
    ILessonsRepository lessonsRepository,
    IAttendanceRepository attendanceRepository)
{
    public async Task ExecuteAsync(DateTime? from = null, int days = 30)
    {
        var startDate = (from ?? DateTime.Today).Date.ToUniversalTime();
        var endDate = startDate.AddDays(days);

        var groups = await groupRepository.GetGroupsByNameAsync();

        foreach (var date in EachDate(startDate, endDate))
        {
            foreach (var group in groups.Where(g => MatchesWeekDay(g.WeekDay, date)))
            {
                var lessonStart = DateTime.SpecifyKind(date.Date.Add(group.StartTime.ToTimeSpan()), DateTimeKind.Utc);
                var lessonEnd = DateTime.SpecifyKind(date.Date.Add(group.EndTime.ToTimeSpan()), DateTimeKind.Utc);

                if (await lessonsRepository.LessonExistsAsync(group.GroupId, lessonStart))
                    continue;

                var qualifyingStudents = group.Students?
                    .Where(s => s.Contract?.HoursRemaining is > 0)
                    .ToList() ?? [];

                var lesson = new Lesson
                {   
                    GroupId = group.GroupId,
                    TeacherId = group.TeacherId,
                    StartTime = lessonStart,
                    EndTime = lessonEnd,
                    Duration = lessonEnd - lessonStart,
                    Status = LessonStatus.Scheduled,
                    IsPaid = false,
                    Students = qualifyingStudents
                };

                await lessonsRepository.AddLessonAsync(lesson);

                foreach (var student in qualifyingStudents)
                {
                    if (await attendanceRepository.AttendanceExistsAsync(lesson.LessonId, student.StudentId))
                        continue;

                    var attendance = new Attendance
                    {
                        StudentId = student.StudentId,
                        LessonId = lesson.LessonId,
                        TeacherId = lesson.TeacherId,
                        Date = lessonStart,
                        AttendanceStatus = AttendanceStatus.Pending,
                        EngagementStatus = EngagmentStatus.NotEngaged
                    };

                    await attendanceRepository.AddAttendanceAsync(attendance);
                }
            }
        }
    }

        private static IEnumerable<DateTime> EachDate(DateTime start, DateTime end)
        {
            for (var date = start; date < end; date = date.AddDays(1))
                yield return date;
        }

        private static bool MatchesWeekDay(string groupWeekDay, DateTime date)
        {
            var ptWeekDay = date.DayOfWeek switch
            {
                DayOfWeek.Monday => "SEG",
                DayOfWeek.Tuesday => "TER",
                DayOfWeek.Wednesday => "QUA",
                DayOfWeek.Thursday => "QUI",
                DayOfWeek.Friday => "SEX",
                DayOfWeek.Saturday => "SAB",
                DayOfWeek.Sunday => "DOM",
                _ => string.Empty
            };

            return groupWeekDay.Equals(ptWeekDay, StringComparison.OrdinalIgnoreCase) ||
                   groupWeekDay.Equals(date.DayOfWeek.ToString()[..3], StringComparison.OrdinalIgnoreCase);
        }
    }
