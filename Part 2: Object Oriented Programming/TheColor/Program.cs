using System.Runtime.ExceptionServices;

namespace TheColorProgram
{
    class Color
    {
        public int _red { get; }
        public int _green { get; }
        public int _blue { get; }

        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        static Color White = new Color(255, 255, 255);
        static Color Black = new Color(0, 0, 0);
        static Color Red = new Color(255, 0 , 0);
        static Color Orange = new Color(255, 165, 0);
        static Color Yellow = new Color(255, 255, 0);
        static Color Green = new Color(0, 128, 0);
        static Color Blue = new Color(0, 0, 255);
        static Color Purple = new Color(128, 0, 128);

        static void Main()
        {
            Color FirstColor = White;
            Color SecondColor = new Color(23, 213, 239);
            Console.WriteLine($"First Color RGB: ({FirstColor._red}, {FirstColor._green}, {FirstColor._blue})");
            Console.WriteLine($"Second Color RGB: ({SecondColor._red}, {SecondColor._green}, {SecondColor._blue})");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}