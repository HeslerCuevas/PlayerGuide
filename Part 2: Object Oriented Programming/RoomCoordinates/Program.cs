namespace RoomCoordinatesProgram
{
    public class MainRuntime
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Coordinate firstCoordinate = new(1, 4);
            Coordinate secondCoordinate = new(2, 4);

            Console.WriteLine($"Is Coordinate 1 adjacent to Coordinate 2? {CheckAdjacent(firstCoordinate, secondCoordinate)}");
        }

        public static bool CheckAdjacent(Coordinate coord1, Coordinate coord2)
        {
            return Math.Abs(coord1.CoordinateRow - coord2.CoordinateRow) <= 1 &&
                    Math.Abs(coord1.CoordinateColumn - coord2.CoordinateColumn) <= 1;

            /* MY ORIGINAL IMPLEMENTATION (PRETTY BAD DESIGN)
            if (coord1.CoordinateRow - 1 == coord2.CoordinateRow && coord1.CoordinateColumn - 1 == coord2.CoordinateColumn)
            {
                //A1
                return true;
            }
            else if (coord1.CoordinateRow - 1 == coord2.CoordinateRow && coord1.CoordinateColumn == coord2.CoordinateColumn)
            {
                //A2
                return true;
            }
            else if (coord1.CoordinateRow - 1 == coord2.CoordinateRow && coord1.CoordinateColumn + 1 == coord2.CoordinateColumn)
            {
                //A3
                return true;
            }
            else if (coord1.CoordinateRow == coord2.CoordinateRow && coord1.CoordinateColumn - 1 == coord2.CoordinateColumn)
            {
                //A4
                return true;
            }
            else if (coord1.CoordinateRow == coord2.CoordinateRow && coord1.CoordinateColumn == coord2.CoordinateColumn)
            {
                //A5
                return true;
            }
            else if (coord1.CoordinateRow == coord2.CoordinateRow && coord1.CoordinateColumn + 1 == coord2.CoordinateColumn)
            {
                //A6
                return true;
            }
            else if (coord1.CoordinateRow + 1 == coord2.CoordinateRow && coord1.CoordinateColumn - 1 == coord2.CoordinateColumn)
            {
                //A7
                return true;
            }
            else if (coord1.CoordinateRow + 1 == coord2.CoordinateRow && coord1.CoordinateColumn == coord2.CoordinateColumn)
            {
                //A8
                return true;
            }
            else if (coord1.CoordinateRow + 1 == coord2.CoordinateRow && coord1.CoordinateColumn + 1 == coord2.CoordinateColumn)
            {
                //A9
                return true;
            }
            else { return false; }
            */

        }
    }

    public readonly struct Coordinate
    {
        public readonly int CoordinateRow { get; }
        public readonly int CoordinateColumn { get; }
        public Coordinate(int row, int column)
        {
            this.CoordinateRow = row;
            this.CoordinateColumn = column;
        }
    }
}