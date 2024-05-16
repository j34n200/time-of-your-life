namespace time_of_your_life.Models.DTO
{
    public class CreateClockPropsDTO
    {
        public string FontFamily { get; set; } = "courier";
        public int[] AvailableFontSizes { get; } = new[] { 12, 24, 48, 64 };
        public int TitleFontSize { get; set; } = 64;
        public int ClockFontSize { get; set; } = 48;
        public bool BlinkColons { get; set; } = true;
        public string FontColor { get; set; } = "black";
        public string ClockFontColor { get; set; } = "blue";
        public string Title { get; set; } = "The Time of Your Life";
        public string TimeZone { get; set; } = "Etc/GMT-5";

    }
}
