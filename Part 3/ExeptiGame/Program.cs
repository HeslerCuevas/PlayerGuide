using System.ComponentModel.Design;

namespace ExeptiGameProgram
{
    public class MainRuntime
    {
        //THERE'S ALSO AN EXE
        public static void Main()
        {
            Console.WriteLine("Welcome to Cookie Exception Game!");
            int turns = 0;
            Random random = new();
            int oatmealRaisinCookie = random.Next(9);
            List<int> cookiesTaken = new();
            CookieGame cookieGame = new();

            do
            {
                bool validInput1 = false;
                do
                {
                    Console.Write("Select a Cookie (Player 1): ");
                    int input1;

                    try
                    {
                        input1 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) { Console.WriteLine("That's not a cookie"); continue; }

                    if (input1 == oatmealRaisinCookie) { Console.WriteLine("Player 1 ate the oatmeal cookie and lost\nPlayer 2 Wins!"); Console.ReadKey(); return; }

                    validInput1 = cookieGame.EatCookie(cookiesTaken, input1);
                }
                while (!validInput1);

                bool validInput2 = false;
                do
                {
                    Console.Write("Select a Cookie (Player 2): ");
                    int input2;

                    try
                    {
                        input2 = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception) { Console.WriteLine("That's not a cookie"); continue; }

                    if (input2 == oatmealRaisinCookie) { Console.WriteLine("Player 2 ate the oatmeal cookie and lost\nPlayer 1 Wins!"); Console.ReadKey(); return; }

                    validInput2 = cookieGame.EatCookie(cookiesTaken, input2);
                }
                while (!validInput2);

                turns++;
            }
            while (turns != 9);
        }
    }

    public class CookieGame
    {
        public bool EatCookie(List<int> cookiesTaken, int input)
        {
            try
            {
                if (input > 9 || input < 0) throw new ArgumentOutOfRangeException();
                else if (cookiesTaken.Contains(input)) throw new CookieTakenException();
                else { cookiesTaken.Add(input); return true; }
            }
            catch (CookieTakenException)
            {
                Console.WriteLine("That cookie is already taken! Please select another one.");
                return false;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("There are 10 cookies, select them from 0 to 9.");
                return false;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Please select a cookie.");
                return false;
            }
        }
    }

    public class CookieTakenException : Exception
    {
        public CookieTakenException() { }
        public CookieTakenException(string message) : base(message) { }
    }
}