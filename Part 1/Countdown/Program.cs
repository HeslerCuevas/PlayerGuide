count(10);

int count(int number)
{
    Console.WriteLine("Testing something");
    Console.WriteLine(number);
    if (number == 1) return 1;
    return count(number - 1);
}
