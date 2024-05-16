namespace time_of_your_life.Models.DTO
{
    public class UpdateClockPropsDTO
    {
        public string FontFamily { get; set; }
        public int[]? AvailableFontSizes { get; } = new[] { 12, 24, 48, 64 };
        public int TitleFontSize { get; set; }
        public int ClockFontSize { get; set; }
        public bool BlinkColons { get; set; }
        public string FontColor { get; set; }
        public string ClockFontColor { get; set; }
        public string Title { get; set; }
        public string TimeZone { get; set; }
    }
}
