using System;
using System.ComponentModel.DataAnnotations;

namespace Jedster.CoreBusiness;

public class Material
{

    public int TextbookId { get; set; }
    [Required] public string BookName { get; set; } = "";
    [Required]
    public Student? Student { get; set; }
    public int StudentId { get; set; }
    public double SuggestedHours  { get; set; } = 40.00;
    
    
}
