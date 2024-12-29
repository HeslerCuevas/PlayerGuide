namespace TheFountainOfProjectsProgramExtension
{
    public class Size
    {
        public int GetGameSize()
        {
            int size = 0;
            do
            {
                ConsoleHelper.Write("Do you to play a small, medium, or large game? ", ConsoleColor.DarkYellow);
                string? getSize = Console.ReadLine();

                switch (getSize?.ToLower())
                {
                    case "small":
                        size = 4;
                        break;
                    case "medium":
                        size = 6;
                        break;
                    case "large":
                        size = 8;
                        break;
                    default:
                        ConsoleHelper.WriteLine($"I did not understand. '{getSize}'", ConsoleColor.Red);
                        break;
                }
            }
            while (size == 0);

            ConsoleHelper.WriteLine($"You have started a {size}x{size} game!", ConsoleColor.Green);
            return size;
        }
    }
}