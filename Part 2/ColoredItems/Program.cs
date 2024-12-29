using System.Security.Cryptography.X509Certificates;

namespace ColoredItemsProgram
{
    public class MainRuntime
    {
        public static void Main()
        {
            ColoredItem<Sword> sword = new(); sword.Display(ConsoleColor.Blue);
            ColoredItem<Bow> bow = new(); bow.Display(ConsoleColor.Red);
            ColoredItem<Axe> axe = new(); axe.Display(ConsoleColor.Green);
            Console.ResetColor();
        }
    }

    public class ColoredItem<T>
    {
        public void Display(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{this.ToString()}\n");
        }
    }
    public class Sword { }
    public class Bow { }
    public class Axe { }
}