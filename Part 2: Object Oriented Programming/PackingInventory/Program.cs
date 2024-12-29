using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace PackingInventoryProgram
{
    public class MainpRuntime
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("This is the PackingInventory Program!\n\nPlease specify your pack attributes!\n");

            Console.Write("Item Capacity: ");
            int itemCapacity;
            while (!int.TryParse(Console.ReadLine(), out itemCapacity) || itemCapacity <= 0)
            {
                Console.Write("Please enter a valid positive number for Item Capacity: ");
            }

            Console.Write("Weight Capacity: ");
            double weightCapacity;
            while (!double.TryParse(Console.ReadLine(), out weightCapacity) || itemCapacity <= 0)
            {
                Console.Write("Please enter a valid positive number for Item Capacity: ");
            }

            Console.Write("Volume Capacity: ");
            double volumeCapacity;
            while (!double.TryParse(Console.ReadLine(), out volumeCapacity) || itemCapacity <= 0)
            {
                Console.Write("Please enter a valid positive number for Item Capacity: ");
            }

            Pack pack = new Pack(itemCapacity, weightCapacity, volumeCapacity);
            Console.WriteLine("\nYour Backpack has been created!");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("What item do you want to add to your pack? \n\n 1-Arrow (Weight: 0.1, Volume: 0.05)\n " +
                    "2-Bow (Weight: 1, " + "Volume: 4)\n 3-Rope (Weight: 1, Volume: 1.5)\n 4-Water (Weight: 2, Volume: 3)\n " +
                    "5-Food (Weight: 1, Volume: 0.5)\n" +" 6-Sword (Weight: 5, Volume: 3)\n 7-Your Pack Items\n");

                string input = Console.ReadLine();

                InventoryItem itemToAdd = null;

                switch (input)
                {
                    case "1":
                        itemToAdd = new InventoryItem.Arrow();
                        break;
                    case "2":
                        itemToAdd = new InventoryItem.Bow();
                        break;
                    case "3":
                        itemToAdd = new InventoryItem.Rope();
                        break;
                    case "4":
                        itemToAdd = new InventoryItem.Water();
                        break;
                    case "5":
                        itemToAdd = new InventoryItem.Food();
                        break;
                    case "6":
                        itemToAdd = new InventoryItem.Sword();
                        break;
                    case "7":
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid selection.");
                        Console.ResetColor();
                        break;
                }

                if (itemToAdd != null && pack.Add(itemToAdd))
                {
                    Console.ForegroundColor = ConsoleColor.Green; Console.Clear();
                    Console.WriteLine("\nYour item was added succesfully! ;)\n");
                    Console.ResetColor();
                }
                else if (input == "7")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Clear();

                    if (pack.currentItems == 0)
                    {
                        Console.WriteLine("Your pack is empty!\n");
                    }
                    else
                    {
                        for (int i = 0; i < pack.currentItems; i++)
                        {
                            Console.WriteLine($"Your Pack Contents: \n{pack.items[i].GetType().Name} - Weight: {pack.items[i].item_Weight}," +
                                $" Volume: {pack.items[i].item_Volume}");
                        }
                        Console.WriteLine();
                    }
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red; Console.Clear();
                    Console.WriteLine("\nYour item has not been added ;( \n");
                    Console.ResetColor();
                }
            }
        }

        public class InventoryItem
        {
            public double item_Weight { get; private set; }
            public double item_Volume { get; private set; }

            public InventoryItem(double Weight, double Volume)
            {
                this.item_Weight = Weight;
                this.item_Volume = Volume;
            }

            public class Arrow : InventoryItem
            {
                public Arrow() : base(0.1, 0.05) { }
            }

            public class Bow : InventoryItem
            {
                public Bow() : base(1, 4) { }
            }

            public class Rope : InventoryItem
            {
                public Rope() : base(1, 1.5) { }
            }

            public class Water : InventoryItem
            {
                public Water() : base(2, 3) { }
            }

            public class Food : InventoryItem
            {
                public Food() : base(1, 0.5) { }
            }

            public class Sword : InventoryItem
            {
                public Sword() : base(5, 3) { }
            }
        }

        public class Pack
        {
            public InventoryItem[] items { get; private set; }
            private double maxWeight { get; set; }
            private double maxVolume { get; set; }

            public int currentItems { get; private set; }
            public double currentVolume { get; private set; }
            public double currentWeight { get; private set; }

            public Pack (int maxItems, double MaxWeight, double MaxVolume)
            {
                this.items = new InventoryItem[maxItems];
                this.maxWeight = MaxWeight;
                this.maxVolume = MaxVolume;
                this.currentItems = 0;
            }

            public bool Add(InventoryItem item)
            {
                if (this.currentItems < this.items.Length && currentVolume + item.item_Volume <= maxVolume && 
                    currentWeight + item.item_Weight <= maxWeight)
                {
                    this.items[currentItems] = item;

                    this.currentItems++;
                    this.currentWeight += item.item_Weight;
                    this.currentVolume += item.item_Volume;

                    return true;
                }
                return false;
            }
        }
    }
}