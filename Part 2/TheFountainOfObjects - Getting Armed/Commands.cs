namespace TheFountainOfProjectsProgramExtension
{
    public class Commands
    {
        public void Execute(Game game)
        {
            ConsoleHelper.Write("What do you want to do? ", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Cyan;

            string? input = Console.ReadLine();

            switch (input?.ToLower())
            {
                case "move east":
                    game.MoveEast();
                    break;
                case "move west":
                    game.MoveWest();
                    break;
                case "move north":
                    game.MoveNorth();
                    break;
                case "move south":
                    game.MoveSouth();
                    break;
                case "shoot east":
                    game.ShootEast();
                    break;
                case "shoot west":
                    game.ShootWest();
                    break;
                case "shoot north":
                    game.ShootNorth();
                    break;
                case "shoot south":
                    game.ShootSouth();
                    break;
                case "enable fountain":
                    game.EnableFountain();
                    break;
                default:
                    ConsoleHelper.WriteLine($"I did not understand. '{input}'", ConsoleColor.Red);
                    break;
            }
        }
    }
}
