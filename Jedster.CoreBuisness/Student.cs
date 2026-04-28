using System;

namespace Jedster.CoreBuisness;

public class Student
{
    public required string RG { get; set; }
    public required string CPF { get; set; }
    public required string Name { get; set; }
    public DateOnly Nasc { get; set; }
    public required int GroupId { get; set; }
    public double HoursCompleted { get; set; } = 0;
    public double HoursMissed { get; set; } = 0;
    public double HoursRemaining { get; set; }

    public required int TextbookId { get; set; }

}
