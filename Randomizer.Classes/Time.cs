namespace Randomizer.Classes
{
    public record Time
    {
        public int Hours { get; init; }
        public int Minutes { get; init; }
        public int Seconds { get; init; }

        public Time() { }
        public Time(int seconds)
        {
            Hours = seconds / 3600;
            Minutes = (seconds % 3600) / 60;
            Seconds = (seconds % 3600) % 60;
        }

        public Time(int minutes, int seconds)
            : this(minutes * 60 + seconds)
        { }

        public Time(int hours, int minutes, int seconds)
            : this(hours * 3600 + minutes * 60 + seconds)
        { }
    }
}
