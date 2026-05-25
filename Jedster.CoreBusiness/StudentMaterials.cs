using System;

namespace Jedster.CoreBusiness;

public class StudentMaterials
{
    public IEnumerable<Material>? Materials { get; set; }
    public int TextbookId { get; set; }
    public Student? Student { get; set; }
    
    public int StudentId { get; set; }
}