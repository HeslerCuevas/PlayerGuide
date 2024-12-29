Console.Write("Enter your name: ");
var name = Console.ReadLine();

Console.WriteLine("The following items are available: ");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing equipment");
Console.WriteLine("4 - Clean water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food supplies");
Console.Write("What number do you want to see the price of? ");

int number = Convert.ToInt32(Console.ReadLine());

double rope = 10;
double torches = 15;
double climbing = 25;
double water = 1;
double machete = 20;
double canoe = 200;
double supplies = 1;

if (name.ToLower() == "hesler")
{
    (rope, torches, climbing, water, machete, canoe, supplies) =
    (rope * 0.5, torches * 0.5, climbing * 0.5, water * 0.5, machete * 0.5, canoe * 0.5, supplies * 0.5);
}

switch(number)
{
    case 1:
        Console.WriteLine($"Ropes are {rope} gold");
        break;
    case 2: 
        Console.WriteLine($"Torches are {torches} gold");
        break;
    case 3:
        Console.WriteLine($"Climbing equipment are {climbing} gold");
        break;
    case 4:
        Console.WriteLine($"Clean water is {water} gold");
        break;
    case 5:
        Console.WriteLine($"Machete are  {machete} gold");
        break;
    case 6:
        Console.WriteLine($"Canoes are {canoe} gold");
        break;
    case 7:
        Console.WriteLine($"Food supplies are {supplies} gold");
        break;
    default:
        Console.WriteLine("That number is not available");
        break;
}