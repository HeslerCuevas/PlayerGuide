using System.Runtime.CompilerServices;

namespace TheFountainOfProjectsProgram
{
    public class MainRuntime
    {
        public static void Main()
        {
            Game game = new();

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"You are in the room at (Row={game.currentRow}, Column={game.currentColumn})");

                Game.CheckRoom(game);
                if (game.end == true) { Console.Write("Press any key to close.");  Console.ReadKey();  break; }

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
                        Game.EnableFountain(game);
                        break;
                    default:
                        ConsoleHelper.WriteLine($"I did not understand. '{input}'", ConsoleColor.Red);
                        break;
                }
            }
            while (game.end == false);
        }
    }

    public class Game
    {
        public int currentRow;
        public int currentColumn;
        public bool Fountain;
        public bool end;
        private readonly Movement movement;

        public Game()
        {
            currentRow = 0;
            currentColumn = 0;
            Fountain = false;
            end = false;
            movement = new Movement(this);
        }

        public static void EnableFountain(Game game)
        {
            if (game.currentRow == 0 && game.currentColumn == 2)
            {
                game.Fountain = true;
            }
            else
            {
                ConsoleHelper.WriteLine("You can't enable the fountain here! cushh...", ConsoleColor.Red);
            }
        }

        public static void CheckRoom(Game game)
        {
            if (game.currentRow == 0 && game.currentColumn == 2 && game.Fountain == true)
            {
                ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Blue);
            }
            else if (game.currentRow == 0 && game.currentColumn == 2)
            {
                ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Blue);
            }
            else if (game.currentRow == 0 && game.currentColumn == 0 && game.Fountain == true)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!", ConsoleColor.Green);
                game.end = true;
            }
            else if (game.currentRow == 0 && game.currentColumn == 0)
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
        private readonly string[,] Room;
        private Game game;

        public Movement(Game game)
        {
            Room = new string[,] {
            { " ", " ", " ", " " },
            { " ", " ", " ", " " },
            { " ", " ", " ", " " },
            { " ", " ", " ", " " }
        };
            this.game = game;
        }

        public void MoveEast()
        {
            try
            {
                Room[game.currentRow, game.currentColumn + 1] = "";
                game.currentColumn += 1;
            }
            catch (Exception) { Invalid(); }
        }

        public void MoveWest()
        {
            try
            {
                Room[game.currentRow, game.currentColumn - 1] = "";
                game.currentColumn -= 1;
            }
            catch (Exception) { Invalid(); }
        }

        public void MoveSouth()
        {
            try
            {
                Room[game.currentRow + 1, game.currentColumn] = "";
                game.currentRow += 1;
            }
            catch (Exception) { Invalid(); }
        }

        public void MoveNorth()
        {
            try
            {
                Room[game.currentRow - 1, game.currentColumn] = "";
                game.currentRow -= 1;
            }
            catch (Exception) { Invalid(); }
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