namespace time_of_your_life.Models;

public class ClockProps
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string FontFamily { get; set; }
    public int[] AvailableFontSizes { get; }
    public int TitleFontSize { get; set; }
    public int ClockFontSize { get; set; }
    public bool BlinkColons { get; set; }
    public string FontColor { get; set; }
    public string ClockFontColor { get; set; }
    public string TimeZone { get; set; }
}