using Jedster.CoreBuisness;
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.Scheduling;

public class GenerateLessonsAndAttendace(
    IGroupRepository groupRepository,
    ILessonsRepository lessonsRepository,
    IAttendanceRepository attendanceRepository,
    ILessonsRepository lessonRepository)

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
                    var lessonStart = date.Add(group.StartTime.ToTimeSpan());
                    var lessonEnd = date.Add(group.EndTime.ToTimeSpan());

                    if (await lessonsRepository.LessonExistsAsync(group.GroupId, lessonStart))
                        continue;

                    var lesson = new Lesson
                    {   
                        GroupId = group.GroupId,
                        Group = group,
                        TeacherId = group.TeacherId,
                        Teacher = group.Teacher,
                        StartTime = lessonStart,
                        EndTime = lessonEnd,
                        Duration = lessonEnd - lessonStart,
                        Status = LessonStatus.Scheduled,
                        IsPaid = false,
                        Students = group.Students?
                            .Where(s => s.Contract?.HoursRemaining is > 0)
                            .ToList(),
                        
                    };
                    
                    foreach (var student in lesson.Students ?? [])
                    {
                        if (await attendanceRepository.AttendanceExistsAsync(lesson.LessonId, student.StudentId))
                            continue;

                        var attendance = new Attendance
                        {
                            
                            StudentId = student.StudentId,
                            Student = student,
                            LessonId = lesson.LessonId,
                            Lesson = lesson,
                            Date = lessonStart,
                            Status = AttendanceStatus.Pending,
                            EngagementStatus = EngagmentStatus.NotEngaged,
                            Teacher = lesson.Teacher,
                            TeacherId = lesson.TeacherId
                        };
                        if (lesson.Attendances != null) lesson.Attendances.Append(attendance);

                        await attendanceRepository.AddAttendanceAsync(attendance);
                    }

                    await lessonRepository.AddLessonAsync(lesson);
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
