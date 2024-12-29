namespace BetterRandomProgram
{
    public class MainRuntime
    {
        public static void Main()
        {
            Random random = new();

            //Generate Random Double
            Console.WriteLine($"Random Double: {random.NextDouble(54)}.");

            //Generate Random String from given strings
            Console.WriteLine($"Random String: {random.NextString("brailer ;)", "hesler", "laura", "massiel", "papi", "mami")}");

            //Generate Random Bool based on Percent probability for true (Heads)
            Console.WriteLine($"Random Bool: {random.CoinFlip(0.75)}");


        }
    }
    public static class RandomExtensions
    {
        public static double NextDouble(this Random random, double max = 1.0)
        {
            return random.NextDouble() * max;
        }

        public static string NextString(this Random random, params string[] strings)
        {
            if (strings.Length == 0) { return "Error, you need to give 1 strings or more to choose from."; }

            int index = random.Next(strings.Length);
            return strings[index];
        }

        public static bool CoinFlip(this Random random, double headsPercent = 0.5)
        {
            //Heads is True, Tails is False

            double probability = random.NextDouble();
            return probability < headsPercent;
        }
    }
}
