Console.Write("Enter number: ");
var number = Convert.ToInt32(Console.ReadLine());
int remainder = number % 2;
if (number % 2 == 0)
{
    Console.WriteLine("Tick");
}
else
{
    Console.WriteLine("Tock");
}