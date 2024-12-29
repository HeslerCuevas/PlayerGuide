int[] numbers = new int[5];

for (int i = 0; i < 5 ; i++)
{
    Console.Write($"Enter number {i + 1}: ");
    numbers[i] = Convert.ToInt32(Console.ReadLine());
}

int [] numbers_copy = new int[5];

for (int i = 0;i < 5 ; i++)
{
    numbers_copy[i] = numbers[i];
}

Console.WriteLine($"Original array: " + string.Join(", ", numbers));
Console.WriteLine($"Copied array: " + string.Join(", ", numbers_copy));