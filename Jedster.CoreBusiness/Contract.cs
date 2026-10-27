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

    public double HoursPresent
    {
        get => HoursCompleted;
        set => HoursCompleted = value;
    }

    public double HoursAbsent
    {
        get => HoursMissed;
        set => HoursMissed = value;
    }
    
    public double GetHoursCompleted() => HoursCompleted;
    public double GetHoursMissed() => HoursMissed;
    public double GetHoursRemaining() => HoursRemaining;
    public double GetHoursPresent() => HoursCompleted;
    public double GetHoursAbsent() => HoursMissed;
    
    public void SetHoursRemaning(double hours)
    {
        HoursRemaining = hours;
    }

    public void SetHoursRemaining(double hours)
    {
        HoursRemaining = hours;
    }

    public void SetHoursCompleted(double hours)
    {
        HoursCompleted = hours;
    }

    public void SetHoursMissed(double hours)
    {
        HoursMissed = hours;
    }
    
}