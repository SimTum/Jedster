using System;

namespace Jedster.CoreBusiness;

public class Textbook
{

    public int id { get; set; }
    public required String Name { get; set; }
    public double SuggestedHours  { get; set; } = 40.00;
    
    
}
