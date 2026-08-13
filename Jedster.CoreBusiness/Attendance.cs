using System.ComponentModel.DataAnnotations; 
using Jedster.CoreBusiness;

namespace Jedster.CoreBuisness;

public class  Attendance
{
    public int EntryId { get; set; }

    public int StudentId { get; set; }
    public Student? Student { get; set; }

    public int LessonId { get; set; }
    public Lesson? Lesson { get; set; }

    public DateTime Date { get; set; }

    public string StudentName { get; set; } = string.Empty;

    public bool IsPresent { get; set; } = false;

    public bool IsAbsent { get; set; } = false;

    public bool HasCancelled { get; set; } = false;

    public int Engagement { get; set; } = 5;

    public string Observations { get; set; } = string.Empty;

    public string Stage { get; set; } = string.Empty;
    public Material? TextBook { get; set; }
}    
    
