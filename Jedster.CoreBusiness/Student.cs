using System;
using System.ComponentModel.DataAnnotations;

namespace Jedster.CoreBusiness;

public class Student
{
    public object? StudentId { get; set; }
    [Required]
    public required string RG { get; set; }
    [Required]
    public required string CPF { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public DateOnly BirthDate { get; set; }
    [Required]
    public required int GroupId { get; set; }
    public double HoursCompleted { get; set; } = 0;
    public double HoursMissed { get; set; } = 0;
    public double HoursRemaining { get; set; } = 40;

    public required int TextbookId { get; set; }
    public Group? Group { get; set; }
    public IEnumerable<Material>? Materials { get ; set; } = new  List<Material>();
}
