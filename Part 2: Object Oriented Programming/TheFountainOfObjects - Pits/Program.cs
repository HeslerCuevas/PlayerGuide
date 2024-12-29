using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TheFountainOfProjectsProgramExtension
{
    public class MainRuntime
    {
        public static void Main()
        {
            ConsoleHelper.WriteLine("Welcome to the Fountain of Objects...", ConsoleColor.Blue);
            Size gameSize = new();
            int size = gameSize.GetGameSize();

            Game game = new Game(size);
            Pits pit = new Pits(size);

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"You are in the room at (Row={game.player.Row}, Column={game.player.Column})");

                if (pit.IsPit(game.player.Row, game.player.Column))
                {
                    game.end = true;
                }

                game.CheckRoom();
                if (game.end == true) { Console.Write("Press any key to close."); Console.ReadKey(); break; }

                pit.IsPitAdjacent(game.player.Row, game.player.Column);

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

            Console.Clear();
            return size;
        }
    }

    public class Pits
    {
        public Pit[] pits = new Pit[4];
        int pitsNumber;

        public Pits(int size)
        {
            switch (size)
            {
                case 4:
                    pitsNumber = 1;
                    pits[0].Row = 2; pits[0].Column = 2;
                    break;
                case 6:
                    pitsNumber = 2;
                    pits[0].Row = 0; pits[0].Column = 0;
                    pits[1].Row = 3; pits[1].Column = 3;
                    break;
                case 8:
                    pitsNumber = 4;
                    pits[0].Row = 5; pits[0].Column = 7;
                    pits[1].Row = 0; pits[1].Column = 4;
                    pits[2].Row = 4; pits[2].Column = 5;
                    pits[3].Row = 7; pits[3].Column = 2;
                    break;
            }
        }

        public bool IsPit(int currentRow, int currentColumn)
        {
            for (int i = 0; i < pitsNumber; i++)
            {
                if (currentRow == pits[i].Row && currentColumn == pits[i].Column)
                {
                    ConsoleHelper.WriteLine("You just falled into a PIT!!!!!", ConsoleColor.Red);
                    Console.WriteLine("You LOST...", ConsoleColor.Red);
                    return true;
                }
            }
            return false;
        }

        public void IsPitAdjacent(int currentRow, int currentColumn)
        {

            int[] rowOffsets = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] colOffsets = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int j = 0; j < pitsNumber; j++)
            {
                for (int i = 0; i < rowOffsets.Length; i++)
                {
                    if (currentRow + rowOffsets[i] == pits[j].Row &&
                        currentColumn + colOffsets[i] == pits[j].Column)
                    {
                        NearbyPit();
                        return;
                    }
                }
            }
        }

        private void NearbyPit()
        {
            ConsoleHelper.WriteLine("You feel a draft. There is a pit in a nearby room.", ConsoleColor.Magenta);
        }
    }

    public class Game
    {
        public Player player;
        internal int fountainRow; internal int fountainColumn;
        internal int entranceRow; internal int entranceColumn;
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

            player.Row = entranceRow;
            player.Column = entranceColumn;
        }

        public void EnableFountain()
        {
            if (player.Row == fountainRow && player.Column == fountainColumn)
            {
                Fountain = true;
            }
            else if (Fountain == true)
            {
                ConsoleHelper.WriteLine("The fountain is already activated! Escape now!", ConsoleColor.Blue);
            }
            else { ConsoleHelper.WriteLine("You can't enable the fountain here! cushh...", ConsoleColor.Red); }
        }

        public void CheckRoom()
        {
            if (player.Row == fountainRow && player.Column == fountainColumn && Fountain == true)
            {
                ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Blue);
            }
            else if (player.Row == fountainRow && player.Column == fountainColumn)
            {
                ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Blue);
            }
            else if (player.Row == entranceRow && player.Column == entranceColumn && Fountain == true)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!", ConsoleColor.Green);
                end = true;
            }
            else if (player.Row == entranceRow && player.Column == entranceColumn)
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
            if (game.player.Column + 1 < size)
            {
                game.player.Column++;
            }
            else { Invalid(); }
        }

        public void MoveWest()
        {
            if (game.player.Column - 1 < size && game.player.Column > 0)
            {
                game.player.Column--;
            }
            else { Invalid(); }
        }

        public void MoveSouth()
        {
            if (game.player.Row + 1 < size)
            {
                game.player.Row++;
            }
            else { Invalid(); }
        }

        public void MoveNorth()
        {
            if (game.player.Row - 1 < size && game.player.Row > 0)
            {
                game.player.Row--;
            }
            else { Invalid(); }
        }

        private void Invalid()
        {
            ConsoleHelper.WriteLine("You can't move there! Cushhh... That room doesn't even exist.", ConsoleColor.Red);
        }
    }

    public struct Pit
    {
        public int Column;
        public int Row;
    }

    public struct Player
    {
        public int Column;
        public int Row;
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