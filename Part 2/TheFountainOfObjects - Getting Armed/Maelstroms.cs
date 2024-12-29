namespace TheFountainOfProjectsProgramExtension
{
    public class Maelstroms : Hazard
    {
        private readonly int _max;
        private readonly int _min;

        public Maelstroms(int size) : base(GetMaelstromsCount(size), "A maelstrom is in the surroundings...", "There is a Maelstrom in the Room!!!\nThe maelstrom changed your position!")
        {
            switch (size)
            {
                case 4:
                    Locations = new Entity[] { new Entity { Row = 3, Column = 2 } };
                    _max = size - 1; _min = 0;
                    break;
                case 6:
                    Locations = new Entity[] { new Entity { Row = 1, Column = 2 } };
                    _max = size - 1; _min = 0;
                    break;
                case 8:
                    Locations = new Entity[] { new Entity { Row = 2, Column = 6 }, new Entity { Row = 4, Column = 4 } };
                    _max = size - 1; _min = 0;
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
                if (playerRow == Locations[i].Row && playerColumn == Locations[i].Column && !Locations[i].IsDefeated)
                {
                    ConsoleHelper.WriteLine("There is a Maelstrom in the Room!!!\nThe maelstrom changed your position!", ConsoleColor.DarkRed);

                    //Maelstrom Effect:
                    playerRow = ClampValue(playerRow - 1, _min, _max);
                    playerColumn = ClampValue(playerColumn + 2, _min, _max);

                    Locations[i].Row = ClampValue(Locations[i].Row + 1, _min, _max);
                    Locations[i].Column = ClampValue(Locations[i].Column - 2, _min, _max);

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
}