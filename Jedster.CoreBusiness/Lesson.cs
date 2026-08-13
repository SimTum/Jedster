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
                    student.Contract is { HoursRemaining: >= -6 });
        }
        else
        {
            Students = new List<Student>();
        }           
    }

    public required int GroupId { get; set; }
    public Group? Group { get; set; }
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    private bool IsPaidFor { get; set; } = false;
    public IEnumerable<Student>? Students { get; set; }
}