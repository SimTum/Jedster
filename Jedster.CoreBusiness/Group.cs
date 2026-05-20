using System;
using System.ComponentModel.DataAnnotations;

namespace Jedster.CoreBusiness;

public class Group
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public int NumberStudents { get; set; }
    [Required]
    public required string WeekDay { get; set; }
    [Required]
    public TimeOnly StartTime { get; set; }
    [Required]
    public TimeOnly EndTime { get; set; }
    [Required]
    public int IdTeacher { get; set; }
    private double PayRate { get; set; } = 20.00;

}
