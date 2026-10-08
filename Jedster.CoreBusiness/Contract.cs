namespace Jedster.CoreBusiness;

public class Contract
{
    public int ContractId { get; set; }
    public Student Student { get; init; }
    public int StudentId { get; set; }
    public DateTime StartDate { get; set; }

    public double HoursCompleted { get; set; } = 0;

    public double HoursMissed { get; set; } = 0;
    public double HoursRemaining { get; set; } = 40;
    
    public double GetHoursCompleted() => HoursCompleted;
    public double GetHoursMissed() => HoursMissed;
    public double GetHoursRemaining() => HoursRemaining;
    
    public void SetHoursRemaning(double hours)
    {
        HoursRemaining = hours;
    }
    
}