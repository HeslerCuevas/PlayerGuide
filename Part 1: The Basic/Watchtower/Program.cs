Console.Write("X: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("Y: ");
int y = Convert.ToInt32(Console.ReadLine());

if(x == 0 && y == 0)
{
    Console.WriteLine("The enemy is here!");
}
else if(x == 0 && y > 0)
{
    Console.WriteLine("The enemy is to the North!");
}
else if (x == 0 && y < 0)
{
    Console.WriteLine("The enemy is to the South!");
}
else if (x < 0 && y > 0)
{
    Console.WriteLine("The enemy is to the Northwest");
}
else if (x < 0 && y == 0)
{
    Console.WriteLine("The enemy is to the West!");
}
else if (x < 0 && y < 0)
{
    Console.WriteLine("The enemy is to the Southwest!");
}
else if (x > 0 && y > 0)
{
    Console.WriteLine("The enemy is to the Northeast!");
}
else if (x > 0 && y < 0)
{
    Console.WriteLine("The enemy is to the Southeast!");
}