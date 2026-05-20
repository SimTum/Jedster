using System;

namespace Jedster.CoreBusiness;

public class Class
{
    public required int GroupId { get; set; }
    public required int TeacherId { get; set; }
    public required DateTime StartTime { get; set; } 
    public required DateTime EndTime { get; set; } 
    private Boolean IsPaidFor { get; set; } = false;

}
