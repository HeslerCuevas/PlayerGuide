int number;
do
{
    Console.Write("User 1, enter a number between 0 and 100: ");
    number = Convert.ToInt32(Console.ReadLine());
}
while (number < 0 || 101 < number);

Console.Clear();

Console.Write("User 2, guess the number: ");
int guess = Convert.ToInt32(Console.ReadLine());

while (guess != number)
{
    Console.Write("What is your next guess? ");
    guess = Convert.ToInt32(Console.ReadLine());
    if (guess > number)
    {
        Console.WriteLine($"{guess} is too high.");
    }
    else if (guess < number)
    {
        Console.WriteLine($"{guess} is too low.");
    }
}

Console.WriteLine("You guessed the number!");