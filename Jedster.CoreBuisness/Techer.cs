using System.ComponentModel.DataAnnotations;

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

        public double Hours { get; set; } = 0;



    }
}
