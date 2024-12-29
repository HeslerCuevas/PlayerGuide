namespace TheFountainOfProjectsProgramExtension
{
    public class Amaroks : Hazard
    {
        public Amaroks(int size) : base(GetAmaroksCount(size), "You can smell the rotten stench of an amarok in a nearby room.", "An Amarok is here!! His attacks come in a RAMPAGE!")
        {
            switch (size)
            {
                case 4:
                    Locations = new Entity[] { new Entity { Row = 3, Column = 3 } };
                    break;
                case 6:
                    Locations = new Entity[] { new Entity { Row = 4, Column = 4 }, new Entity { Row = 5, Column = 1 } };
                    break;
                case 8:
                    Locations = new Entity[] { new Entity { Row = 3, Column = 7 }, new Entity { Row = 0, Column = 2 }, new Entity { Row = 2, Column = 4 } };
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
}