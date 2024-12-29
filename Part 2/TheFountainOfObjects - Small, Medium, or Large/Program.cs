using System.Runtime.CompilerServices;

namespace TheFountainOfProjectsProgramExtension
{
    public class MainRuntime
    {
        public static void Main()
        {
            GameSize gameSize = new();
            int size = gameSize.GetGameSize();

            Game game = new Game(size);

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"You are in the room at (Row={game.currentRow}, Column={game.currentColumn})");

                game.CheckRoom();
                if (game.end == true) { Console.Write("Press any key to close."); Console.ReadKey(); break; }

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
                    case "enable fountain":
                        game.EnableFountain();
                        break;
                    default:
                        ConsoleHelper.WriteLine($"I did not understand. '{input}'", ConsoleColor.Red);
                        break;
                }
            }
            while (game.end == false);
        }
    }

    public class GameSize
    {
        public int GetGameSize()
        {
            ConsoleHelper.WriteLine("Welcome to the gameeeee!", ConsoleColor.DarkMagenta);
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

            Console.Clear();
            return size;
        }
    }

    public class Game
    {
        public int currentRow; public int currentColumn;
        private int fountainRow; private int fountainColumn;
        private int entranceRow; private int entranceColumn;
        public bool Fountain;
        public bool end;
        private readonly Movement movement;

        public Game(int size)
        {
            Fountain = false;
            end = false;
            movement = new Movement(this, size);

            switch (size)
            {
                case 4:
                    fountainRow = 0; fountainColumn = 2;
                    entranceRow = 0; entranceColumn = 0;
                    break;
                case 6:
                    fountainRow = 2; fountainColumn = 4;
                    entranceRow = 5; entranceColumn = 5;
                    break;
                case 8:
                    fountainRow = 4; fountainColumn = 3;
                    entranceRow = 7; entranceColumn = 1;
                    break;
            }

            currentRow = entranceRow;
            currentColumn = entranceColumn;
        }

        public void EnableFountain()
        {
            if (currentRow == fountainRow && currentColumn == fountainColumn)
            {
                Fountain = true;
            }
            else if (Fountain == true)
            {
                ConsoleHelper.WriteLine("The fountain is alreadyo activated! Escape now!", ConsoleColor.Blue);
            }
            else { ConsoleHelper.WriteLine("You can't enable the fountain here! cushh...", ConsoleColor.Red); }
        }

        public void CheckRoom()
        {
            if (currentRow == fountainRow && currentColumn == fountainColumn && Fountain == true)
            {
                ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Blue);
            }
            else if (currentRow == fountainRow && currentColumn == fountainColumn)
            {
                ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Blue);
            }
            else if (currentRow == entranceRow && currentColumn == entranceColumn && Fountain == true)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!", ConsoleColor.Green);
                end = true;
            }
            else if (currentRow == entranceRow && currentColumn == entranceColumn)
            {
                Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
            }
        }

        public void MoveEast() => movement.MoveEast();
        public void MoveWest() => movement.MoveWest();
        public void MoveSouth() => movement.MoveSouth();
        public void MoveNorth() => movement.MoveNorth();
    }

    public class Movement
    {
        private Game game;
        private readonly int size;

        public Movement(Game game, int size)
        {
            this.game = game;
            this.size = size;
        }

        public void MoveEast()
        {
            if (game.currentColumn + 1 < size)
            {
                game.currentColumn++;
            }
            else { Invalid(); }
        }

        public void MoveWest()
        {
            if (game.currentColumn - 1 < size && game.currentColumn > 0)
            {
                game.currentColumn--;
            }
            else { Invalid(); }
        }

        public void MoveSouth()
        {
            if (game.currentRow + 1 < size)
            {
                game.currentRow++;
            }
            else { Invalid(); }
        }

        public void MoveNorth()
        {
            if (game.currentRow - 1 < size && game.currentRow > 0)
            {
                game.currentRow--;
            }
            else { Invalid(); }
        }

        private void Invalid()
        {
            ConsoleHelper.WriteLine("You can't move there! Cushhh... That room doesn't even exist.", ConsoleColor.Red);
        }
    }

    public static class ConsoleHelper
    {
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
    }
}