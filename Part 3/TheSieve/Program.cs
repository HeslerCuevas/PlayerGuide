namespace TheSieveProgram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;

    public class MainRuntime
    {
        static void Main()
        {
            Sieve sieve;

            do
            {
                try
                {
                    Console.WriteLine("This is the Numeromechanical Sieve, select a filter for your numbers." +
                    "\n1-Is Even?\n2-Is Positive?\n3-Is Multiple of 10?");
                    string input;
                    int choice;

                    try
                    {
                        input = Console.ReadLine();
                        choice = int.Parse(input);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    if (string.IsNullOrEmpty(input))
                    {
                        throw new ArgumentException("Input cannot be null or empty");
                    }

                    sieve = choice switch
                    {
                        1 => new Sieve(n => n % 2 == 0),
                        2 => new Sieve(n => n > 0),
                        3 => new Sieve(n => n % 10 == 0),
                        _ => throw new ArgumentException()
                    };
                    break;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid choice");
                    continue;
                }
            }
            while(true);

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter a number to check if it is good or bad:");
                var number = int.Parse(Console.ReadLine());
                sieve.IsGood(number);
            } while (true);
        }
    }

    public class Sieve
    {
        private readonly Func<int, bool> _sieveFunction;
        public Sieve(Func<int, bool> Function)
        {
            _sieveFunction = Function;
        }

        public bool IsGood(int number)
        {
            Console.Clear();
            if (_sieveFunction(number))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{number} is good");
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{number} is bad");
            return false;
        }
    }

    public class Functions
    {
        internal bool IsEven(int number) { return number % 2 == 0; }

        internal bool IsPositive(int number) { return number > 0; }

        internal bool IsMultipleOfTen(int number) { return number % 10 == 0; }
    }   
}