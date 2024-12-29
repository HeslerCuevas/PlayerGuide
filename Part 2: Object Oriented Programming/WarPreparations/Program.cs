namespace WarPreparationsProgram
{
    public class MainRuntime
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Sword sword1 = new(Material.Iron, Gemstone.NoGemstone, 2.4, 3.5);
            Sword sword2 = sword1 with {  Material = Material.RareBinarium, GemStone = Gemstone.Esmerald};
            Sword sword3 = sword1 with { CrosswardWidth = 5.5, Material = Material.Steel, Lenght = 8.7, GemStone = Gemstone.Amber};

            Console.WriteLine(sword1);
            Console.WriteLine(sword2);
            Console.WriteLine(sword3);
        }
    }

    public record Sword(Material Material, Gemstone GemStone, double Lenght, double CrosswardWidth);
    public enum Material { Wood, Bronze, Iron, Steel, RareBinarium }
    public enum Gemstone { Esmerald, Amber, Sapphire, Diamond, RareBitstone, NoGemstone}
}