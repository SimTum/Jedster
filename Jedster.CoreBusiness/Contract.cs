namespace Jedster.CoreBusiness;

public class Contract
{
    public int ContractId { get; set; }
    public Student Student { get; set; }
    public int StudentId { get; set; }

    private double HoursCompleted { get; set; } = 0;
    private double HoursMissed { get; set; } = 0;
    private double HoursRemaining { get; set; } = 40;
    
    public double GetHoursCompleted() => HoursCompleted;
    public double GetHoursMissed() => HoursMissed;
    public double GetHoursRemaining() => HoursRemaining;
    
}