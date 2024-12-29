namespace TheFountainOfProjectsProgramExtension
{
    public class Pits : Hazard
    {

        public Pits(int size) : base(GetPitCount(size), "You feel a draft. There is a pit in a nearby room.", "You just fell into a PIT!!!!!\nYou LOST...")
        {
            switch (size)
            {
                case 4:
                    Locations[0] = new Entity { Row = 2, Column = 2 };
                    break;
                case 6:
                    Locations[0] = new Entity { Row = 0, Column = 0 };
                    Locations[1] = new Entity { Row = 3, Column = 3 };
                    break;
                case 8:
                    Locations[0] = new Entity { Row = 5, Column = 7 };
                    Locations[1] = new Entity { Row = 0, Column = 4 };
                    Locations[2] = new Entity { Row = 4, Column = 5 };
                    Locations[3] = new Entity { Row = 7, Column = 2 };
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
}