namespace Jedster.CoreBusiness;

public class Contract
{

    public int ContractId { get; set; }
    
    public int StudentId { get; set; }
    
    public double HoursCompleted { get; set; } = 0;
    public double HoursMissed { get; set; } = 0;
    public double HoursRemaining { get; set; } = 40;

}