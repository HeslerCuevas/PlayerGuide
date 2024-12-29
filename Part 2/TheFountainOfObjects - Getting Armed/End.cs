namespace TheFountainOfProjectsProgramExtension
{
    public record End
    {
        public void EndGame(Game game, DateTime start)
        {
            TimeSpan timeSpan = DateTime.Now - start;
            Console.WriteLine($"Time Spent: {timeSpan.Hours}h:{timeSpan.Minutes}m:{timeSpan.Seconds}s");
            Console.Write("Press any key to close."); Console.ReadKey();
        }
    }
}