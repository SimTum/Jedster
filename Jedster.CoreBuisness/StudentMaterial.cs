using System;

namespace Jedster.CoreBusiness;

public class StudentMaterial
{
    public int SerialNum { get; set; }
    public required int TextbookId { get; set; }
    public required int StudentId { get; set; }
}
