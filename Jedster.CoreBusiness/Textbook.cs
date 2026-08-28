using System;
using System.ComponentModel.DataAnnotations;
using Jedster.CoreBuisness;

namespace Jedster.CoreBusiness;

public class Textbook
{

    [Required ]
    public int TextbookId { get; set; }
    public int TextbookTypeId { get; set; }
    public TextbookData TextbookData { get; set; }
    public string Title { get; set; }
    public int StudentId { get; set; }
    public double HoursSpent { get; set; }
    public double Engagement { get; set; }
    
}
