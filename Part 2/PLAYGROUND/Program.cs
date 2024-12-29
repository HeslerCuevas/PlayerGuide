string? input = Console.ReadLine();
if (int.TryParse(input))
    Console.WriteLine($"You entered {input}.");
else
    Console.WriteLine("That is not a number!");

Console.ReadKey();