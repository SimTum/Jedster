using System;
using System.ComponentModel.DataAnnotations;
using Jedster.CoreBuisness;

namespace Jedster.CoreBusiness;

public class Student
{
    public int StudentId { get; set; }
    [Required]
    public required string RG { get; set; }
    [Required]
    public required string CPF { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public DateOnly BirthDate { get; set; }
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
    [Required]
    public Contract? Contract { get; set; }
    public IEnumerable<Textbook>? Textbooks { get ; set; } = new  List<Textbook>();
    public IEnumerable<Attendance>? Attendance { get; set; } = new List<Attendance>();
    public IEnumerable<Lesson>? Lessons { get; set; } = new List<Lesson>();
}
