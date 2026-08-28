namespace Jedster.CoreBuisness;

public class TextbookData
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double HoursRecommended { get; set; } = 40;
    public string Subject { get; set; }
    public int Level {get; set; }
}