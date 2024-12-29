namespace ThePoint_Program
{
    class Point
    {
        public float CoordinateX { get; set; }
        public float CoordinateY { get; set; }

        //Constructor Parameters
        public Point(float coordinateX, float coordinateY)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
        }

        //Constructor Parameterless
        public Point()
        {
            this.CoordinateX = 0;
            this.CoordinateY = 0;
        }
    }

    class method
    {
        static void Main()
        {
            Point point1 = new Point(2, 3);
            Point point2 = new Point(-4, 0);

            Console.WriteLine($"Point one is at coordinate ({point1.CoordinateX}, {point2.CoordinateY})");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}