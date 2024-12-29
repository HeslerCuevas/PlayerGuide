int manticore_health = 10;
int city_health = 15;
int round = 1;
int manticore_place;
int cannon_range;
bool end = false;
int damage;

void main()
{
    askUser1();
    Console.Clear();
    Console.WriteLine("Player 2, it is your turn");
    do
    {
        CannonDamage();
        Status();

        Console.Write("Enter desired canon range: ");
        cannon_range = Convert.ToInt32(Console.ReadLine());
        DamageDone();

        CheckEnd();

        city_health--;
        round++;
    }
    while (end == false);
}
void askUser1()
{
    do
    {
        Console.Write("Player 1, how far away from the city do you want to station the Manticore? ");
        manticore_place = Convert.ToInt32(Console.ReadLine());
    }
    while (manticore_place > 100 || manticore_place < 0);
}

void CannonDamage()
{
    damage = 1;
    if (round % 3 == 0 && round % 5 == 0)
    {
        damage = 10;
    }
    else if (round % 5 == 0 || round % 3 == 0)
    {
        damage = 3;
    }
}

void Status()
{
    Console.WriteLine($"STATUS: Round {round}  City: {city_health}/15  Manticore: {manticore_health}/10");
    Console.WriteLine($"The cannon is expected to deal {damage} damage this round.");
}

void DamageDone()
{
    if (cannon_range == manticore_place)
    {
        Console.WriteLine("That round was a DIRECT HIT!");
        manticore_health -= damage;
    }
    else if (cannon_range > manticore_place)
    {
        Console.WriteLine("That round OVERSHOT the target.");
    }
    else if (cannon_range < manticore_place)
    {
        Console.WriteLine("That round FELL SHORT of the target");
    }
}

void CheckEnd()
{
    if (manticore_health <= 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        end = true;
    }
    else if (city_health == 1)
    {
        Console.WriteLine("The City has been destroyed! The Manticore has won!");
        end = true;
    }
}

main();