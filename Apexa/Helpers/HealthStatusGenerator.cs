namespace Apexa.Helpers
{
    public static class HealthStatusGenerator
    {
        public static string Generate()
        {
            var random = new Random();
            int value = random.Next(1, 101);
            if (value <= 60) return "Green";
            if (value <= 80) return "Yellow";
            return "Red";
        }
    }
}
