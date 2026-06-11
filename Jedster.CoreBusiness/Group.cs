using System;
using System.ComponentModel.DataAnnotations;

namespace Jedster.CoreBusiness;

public class Group
{
    public int GroupId { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3,
        ErrorMessage = "Nome da turma deve ser um nome único, e deve conter entre 3 e 30 caracters")]
    public string Name { get; set; }

    public int NumberStudents { get; set; }

    [Required]
    [StringLength(3, MinimumLength = 3, ErrorMessage = "Digite dia da semana no padrão de 3 caracteres")]
    public string WeekDay { get; set; }

    [Required] public TimeOnly StartTime { get; set; }
    [Required] public TimeOnly EndTime { get; set; }
    [Required] public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public IEnumerable<Student>? Students { get; set; } = new List<Student>();
    // [Required] public double PayRate { get; set; } 

    public void UpdateTeacherHours()
    {
        Teacher.Hours += (EndTime - StartTime).TotalHours;
        // Teacher.HoursWeighed += (EndTime - StartTime).TotalHours * PayRate / 25.00;
    }
    
}