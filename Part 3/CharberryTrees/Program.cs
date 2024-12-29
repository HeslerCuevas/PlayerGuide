namespace CharberryTreesProgram
{
    class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CharberryTree tree = new();
            Notifier notifier = new(tree);
            Harvester harvester = new(tree);

            while (true)
            {
                tree.MaybeGrow();
            }
        }
        public class CharberryTree
        {
            private readonly Random _random = new();
            public bool Ripe { get; set; }
            public event Action Ripened = () => { };
            public void MaybeGrow()
            {
                // Only a tiny chance of ripening each time, but we try a lot!
                if (_random.NextDouble() < 0.00000001 && !Ripe)
                {
                    Ripe = true;
                    Ripened();
                }
            }
        }

        public class Notifier
        {
            private static void OnRipened()
            {
                Console.WriteLine("A charberry fruit has ripened!");
            }
            public Notifier(CharberryTree tree)
            {
                tree.Ripened += OnRipened;
            }
        }

        public class Harvester
        {
            private int _harvestCount;
            private readonly CharberryTree _Tree;
            public Harvester(CharberryTree tree)
            {
                _harvestCount = 0;
                _Tree = tree;
                _Tree.Ripened += OnRipened;
            }

            private void OnRipened()
            {
                _harvestCount++;
                _Tree.Ripe = false;
                Console.WriteLine($"Harvested {_harvestCount} charberry fruits");
            }
        }
    }
}