using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Jedster.CoreBuisness;

namespace Jedster.CoreBusiness;

public class Lesson
{
    public Lesson()
    {
        if (Group != null)
        {
            if (Group.Students != null)
                Students = Group.Students.Where(student =>
                    student.Contract?.GetHoursRemaining() >= -6 || (student.Contract?.HoursRemaining > 0));
        }
        else
        {
            Students = new List<Student>();
        }           
        Duration = EndTime >= StartTime 
            ? EndTime - StartTime 
            : TimeSpan.Zero;
    }

    public int LessonId { get; set; }
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public TimeSpan Duration { get; set; }
    public LessonStatus Status { get; set; }
    public bool IsPaid { get; set; }
    public IEnumerable<Student>? Students { get; set; }
    public IEnumerable<Attendance>? Attendances { get; set; }
}

public enum LessonStatus
{
    Scheduled = 0,
    InProgress = 1,
    Completed = 2,
    Canceled = 3,
}