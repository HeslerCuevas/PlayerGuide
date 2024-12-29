using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

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
            Maelstroms maelstrom = new Maelstroms(size, game.player);
            Amaroks amaroks = new Amaroks(size);

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine($"You are in the room at (Row={game.player.Row}, Column={game.player.Column})");

                maelstrom.MaelstromEffect(ref game.player.Row, ref game.player.Column, size);

                if (pit.CheckEncounter(game.player.Row, game.player.Column)) { game.end = true;  }
                else if (amaroks.CheckEncounter(game.player.Row, game.player.Column)) { game.end = true; }

                game.CheckRoom();
                if (game.end) { Console.Write("Press any key to close."); Console.ReadKey(); break; }

                pit.CheckProximity(game.player.Row, game.player.Column);
                maelstrom.CheckProximity(game.player.Row, game.player.Column);
                amaroks.CheckProximity(game.player.Row, game.player.Column);

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
            while (!game.end);
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

            ConsoleHelper.WriteLine($"You have started a {size}x{size} game!", ConsoleColor.Green);
            return size;
        }
    }
    
    public abstract class Hazard
    {
        protected Entity[] locations;
        private readonly string proximityMessage;
        private readonly string encounterMessage;

        protected Hazard(int count, string proximityMessage, string encounterMessage)
        {
            locations = new Entity[count];
            this.proximityMessage = proximityMessage;
            this.encounterMessage = encounterMessage;
        }

        public bool CheckEncounter(int playerRow, int playerColumn)
        {
            foreach (var location in locations)
            {
                if (location.Row == playerRow && location.Column == playerColumn)
                {
                    ConsoleHelper.WriteLine(encounterMessage, ConsoleColor.Red);
                    return true;
                }
            }
            return false;
        }

        public void CheckProximity(int playerRow, int playerColumn)
        {
            foreach (var location in locations)
            {
                if (Math.Abs(location.Row - playerRow) <= 1 && Math.Abs(location.Column - playerColumn) <= 1)
                {
                    ConsoleHelper.WriteLine(proximityMessage, ConsoleColor.Magenta);
                    break;
                }
            }
        }
    }
    

    public class Pits : Hazard
    {
        private Entity[] pits = new Entity[4] { new Entity(), new Entity(), new Entity(), new Entity() };

        public Pits(int size)   : base(GetPitCount(size), "You feel a draft. There is a pit in a nearby room.", "You just fell into a PIT!!!!!\nYou LOST...")
        {
            switch (size)
            {
                case 4:
                    locations[0] = new Entity { Row = 2, Column = 2 };
                    break;
                case 6:
                    locations[0] = new Entity { Row = 0, Column = 0 };
                    locations[1] = new Entity { Row = 3, Column = 3 };
                    break;
                case 8:
                    locations[0] = new Entity { Row = 5, Column = 7 };
                    locations[1] = new Entity { Row = 0, Column = 4 };
                    locations[2] = new Entity { Row = 4, Column = 5 };
                    locations[3] = new Entity { Row = 7, Column = 2 };
                    break;
            }
        }

        private static int GetPitCount(int size) => size switch
        {
            4 => 1,
            6 => 2,
            8 => 4,
            _ => 0
        };
    }

    public class Maelstroms : Hazard
    {
        private Entity[] maelstrom = new Entity[2] { new Entity(), new Entity() };
        private int max;
        private int min;

        public Maelstroms(int size, Entity player) : base(GetMaelstromsCount(size), "A maelstrom is in the surroundings...", "There is a Maelstrom in the Room!!!\nThe maelstrom changed your position!")
        {
            switch (size)
            {
                case 4:
                    locations[0] = new Entity { Row = 3, Column = 2 };
                    max = size - 1; min = 0;
                    break;
                case 6:
                    locations[0] = new Entity { Row = 1, Column = 2 };
                    max = size - 1; min = 0;
                    break;
                case 8:
                    locations[0] = new Entity { Row = 2, Column = 6 };
                    locations[1] = new Entity { Row = 4, Column = 4 };
                    max = size - 1; min = 0;
                    break;
            }
        }

        private static int GetMaelstromsCount(int size) => size switch
        {
            4 => 1,
            6 => 1,
            8 => 2,
            _ => 0
        };

        public void MaelstromEffect(ref int playerRow, ref int playerColumn, int size)
        {
            for (int i = 0; i < GetMaelstromsCount(size); i++)
            {
                if (playerRow == locations[i].Row && playerColumn == locations[i].Column)
                {
                    ConsoleHelper.WriteLine("There is a Maelstrom in the Room!!!\nThe maelstrom changed your position!", ConsoleColor.DarkRed);

                    //Maelstrom Effect:
                    playerRow = ClampValue(playerRow - 1, min, max);
                    playerColumn = ClampValue(playerColumn + 2, min, max);

                    locations[i].Row = ClampValue(locations[i].Row + 1, min, max);
                    locations[i].Column = ClampValue(locations[i].Column - 2, min, max);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("----------------------------------------------------------------------------------");
                    Console.WriteLine($"You are in the room at (Row={playerRow}, Column={playerColumn})");
                }
            }
        }

        private int ClampValue(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(value, max));
        }
    }

    public class Amaroks : Hazard
    {
        private Entity[] amaroks = new Entity[3] { new Entity(), new Entity(), new Entity() };

        public Amaroks(int size) : base(GetAmaroksCount(size), "You can smell the rotten stench of an amarok in a nearby room.", "An Amarok is here!! His attacks come in a RAMPAGE!")
        {
            switch (size)
            {
                case 4:
                    locations[0] = new Entity { Row = 3, Column = 3 };
                    break;
                case 6:
                    locations[0] = new Entity { Row = 4, Column = 4 };
                    locations[1] = new Entity { Row = 5, Column = 1 };
                    break;
                case 8:
                    locations[0] = new Entity { Row = 3, Column = 7 };
                    locations[1] = new Entity { Row = 0, Column = 2 };
                    locations[2] = new Entity { Row = 2, Column = 4 };
                    break;
            }
        }

        private static int GetAmaroksCount(int size) => size switch
        {
            4 => 1,
            6 => 2,
            8 => 3,
            _ => 0
        };
    }

    public class Game
    {
        public Entity player;
        public int fountainRow; public int fountainColumn;
        public int entranceRow; public int entranceColumn;
        public bool Fountain;
        public bool end;
        private readonly Movement movement;
        private FountainLogic fountainLogic;
        private RoomLogic roomLogic;

        public Game(int size)
        {
            end = false;
            movement = new Movement(this, size);
            fountainLogic = new FountainLogic(this);
            roomLogic = new RoomLogic(this);
            Fountain = false;

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

        public void EnableFountain() => fountainLogic.EnableFountain();

        public void CheckRoom() => roomLogic.CheckRoom();

        public void MoveEast() => movement.MoveEast();
        public void MoveWest() => movement.MoveWest();
        public void MoveSouth() => movement.MoveSouth();
        public void MoveNorth() => movement.MoveNorth();
    }

    public class FountainLogic
    {
        private Game game;
        public FountainLogic(Game game) { this.game = game; }

        public void EnableFountain()
        {
            if (game.player.Row == game.fountainRow && game.player.Column == game.fountainColumn)
            {
                game.Fountain = true;
            }
            else if (game.Fountain == true)
            {
                ConsoleHelper.WriteLine("The fountain is already activated! Escape now!", ConsoleColor.Blue);
            }
            else { ConsoleHelper.WriteLine("You can't enable the fountain here! cushh...", ConsoleColor.Red); }
        }
    }

    public class RoomLogic
    {
        private Game game;
        public RoomLogic(Game game) { this.game = game; }

        public void CheckRoom()
        {
            if (game.player.Row == game.fountainRow && game.player.Column == game.fountainColumn && game.Fountain == true)
            {
                ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Blue);
            }
            else if (game.player.Row == game.fountainRow && game.player.Column == game.fountainColumn)
            {
                ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Blue);
            }
            else if (game.player.Row == game.entranceRow && game.player.Column == game.entranceColumn && game.Fountain == true)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!", ConsoleColor.Green);
                game.end = true;
            }
            else if (game.player.Row == game.entranceRow && game.player.Column == game.entranceColumn)
            {
                Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
            }
        }
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

    public struct Entity
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