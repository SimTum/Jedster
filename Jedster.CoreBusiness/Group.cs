using System;
using System.ComponentModel.DataAnnotations;

namespace Jedster.CoreBusiness;

public class Group
{
    public int GroupId { get; set; }
    [Required] public string Name { get; set; }
    public int NumberStudents { get; set; }

    [Required]
    [StringLength(3, ErrorMessage = "Digite dia da semana no padrão de 3 caracteres")]
    public string WeekDay { get; set; }

    [Required] public TimeOnly StartTime { get; set; }
    [Required] public TimeOnly EndTime { get; set; }
    [Required] public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public IEnumerable<Student>? Students { get; set; } = new List<Student>();
}