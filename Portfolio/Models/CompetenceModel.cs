namespace Portfolio.Models;

public class CompetenceModel
{
    public string Title { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string? MoreInfo { get; set; }
    public int Rating { get; set; }
}
