using System;
using System.ComponentModel.DataAnnotations;

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
    
    [Required]
    public required int GroupId { get; set; }
    public Group? Group { get; set; }
    
    [Required]
    public Contract? Contract { get; set; }
    
    [Required]
    public required int TextbookId { get; set; }
    public IEnumerable<Textbook>? Textbooks { get ; set; } = new  List<Textbook>();

}
