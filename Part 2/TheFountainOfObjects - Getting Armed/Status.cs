namespace TheFountainOfProjectsProgramExtension
{
    public record Status
    {
        public void DisplayStatus(Game game)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={game.Player.Row}, Column={game.Player.Column})");
        }
    }
}