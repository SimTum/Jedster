using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Jedster.CoreBusiness
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Campo obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string Email { get; set; } = string.Empty;

        [Required] public string RG { get; set; } = string.Empty;

        // [Required]
        // [DataType(DataType.Date)]
        // [Range(typeof(DateTime), "01/01/1900", "01/01/2008",  ErrorMessage = "Data Invalida")]   
        public DateOnly BirthDate { get; set; }

        public string CPF { get; set; } = string.Empty;
        [Range(0, double.MaxValue)] public double Hours { get; set; } = 0;
        [Range(0, double.MaxValue)] public double HoursWeighed { get; set; } = 0;
        public IEnumerable<Group>? Groups { get; set; } = new List<Group>();
    }
}