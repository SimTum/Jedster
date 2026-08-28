using System.ComponentModel.DataAnnotations; 
using Jedster.CoreBusiness;

namespace Jedster.CoreBuisness;

public class  Attendance
{
    public int EntryId { get; set; }

    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public int LessonId { get; set; }
    public AttendanceStatus? Status { get; set; }
    public EngagmentStatus? EngagementStatus { get; set; }
    public Lesson? Lesson { get; set; }

    public DateTime Date { get; set; }

    public Student StudentInfo { get; set; }
    
}

public enum AttendanceStatus
{
    Pending = 0,
    Present = 1,
    Abscent = 2,
    Canceled = 3
}

public enum EngagmentStatus
{
    NotEngaged = 0,
    SlightlyEngaged = 1,
    Engaged = 2,
    VeryEngaged = 3,
}