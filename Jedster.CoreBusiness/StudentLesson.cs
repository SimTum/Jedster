using Jedster.CoreBusiness;

namespace Jedster.CoreBuisness;

public class StudentLesson
{
    public int StudentId {get; set;}
    public int LessonId {get; set;}
    public Student Student { get; set; } = null!;
    public Lesson Lesson { get; set; } = null!;
}