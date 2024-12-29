using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeProgram
{
    public class Game
    {
        static public void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Tic Tac Toe!\nTo play, keep in mind the numpad on your keyboard " +
                    "but play with the normal numbers!\n\nPlayer 1 is X\nPlayer 2 is O");
                Match match = new();
                match.ShowMatch();

                int result;
                int turns = 0;

                do
                {
                    match.Play("X");
                    Console.Clear();
                    match.ShowMatch();

                    turns++;
                    if (turns == 9)
                    {
                        Console.WriteLine("It's a DRAW!!!!\n\nPress any key to play again!");
                        Console.ReadKey();
                        break;
                    }

                    result = match.Result("X");
                    if (result == 1) { break; }

                    match.Play("O");
                    Console.Clear();
                    match.ShowMatch();

                    turns++;

                    result = match.Result("O");
                    if (result == 1) { break; }
                }
                while (result == 0);
            }

        }

        public class Match
        {

            public string[,] Positions = {
        {" ", " ", " "},
        {" ", " ", " "},
        {" ", " ", " "}
        };

            public void Play(string player)
            {
                string c = player;
                bool isValid;

                do
                {
                    isValid = false;
                    Console.Write("\nType your next move: ");
                    string move = Console.ReadLine();

                    switch (move)
                    {
                        case "1":
                            if (Positions[2, 0] == " ") { Positions[2, 0] = c; isValid = true; } 
                            break;
                        case "2":
                            if (Positions[2, 1] == " ") { Positions[2, 1] = c; isValid = true; } 
                            break;
                        case "3":
                            if (Positions[2, 2] == " ") { Positions[2, 2] = c; isValid = true; } 
                            break;
                        case "4":
                            if (Positions[1, 0] == " ") { Positions[1, 0] = c; isValid = true; } 
                            break;
                        case "5":
                            if (Positions[1, 1] == " ") { Positions[1, 1] = c; isValid = true; } 
                            break;
                        case "6":
                            if (Positions[1, 2] == " ") { Positions[1, 2] = c; isValid = true; } 
                            break;
                        case "7":
                            if (Positions[0, 0] == " ") { Positions[0, 0] = c; isValid = true; } 
                            break;
                        case "8":
                            if (Positions[0, 1] == " ") { Positions[0, 1] = c; isValid = true; } 
                            break;
                        case "9":
                            if (Positions[0, 2] == " ") { Positions[0, 2] = c; isValid = true; } 
                            break;
                        default:
                            Console.WriteLine("Play a valid position");
                            break;
                    }
                }
                while (isValid == false);
            }

            public void ShowMatch()
            {
                Console.WriteLine();

                Console.WriteLine($"  {Positions[0, 0]}  |  {Positions[0, 1]}  |  {Positions[0, 2]} ");
                Console.WriteLine($"-----+-----+-----");
                Console.WriteLine($"  {Positions[1, 0]}  |  {Positions[1, 1]}  |  {Positions[1, 2]} ");
                Console.WriteLine($"-----+-----+-----");
                Console.WriteLine($"  {Positions[2, 0]}  |  {Positions[2, 1]}  |  {Positions[2, 2]} ");
            }

            public int Result(string player)
            {
                string c = player;

                //Rows
                for (int row = 0; row < 3; row++)
                {
                    if (Positions[row, 0] == c &&
                        Positions[row, 1] == c &&
                        Positions[row, 2] == c)
                    {
                        Console.WriteLine($"\nPlayer {c} WINS!!!!!!!!\n\nPress any key to play again!");
                        Console.ReadKey();
                        return 1;
                    }
                }

                //Columns
                for (int column = 0; column < 3; column++)
                {
                    if (Positions[0, column] == c &&
                        Positions[1, column] == c &&
                        Positions[2, column] == c)
                    {
                        Console.WriteLine($"\nPlayer {c} WINS!!!!!!!!\n\nPress any key to play again!");
                        Console.ReadKey();
                        return 1;
                    }
                }

                //Diagonals
                for (int diagonals = 0; diagonals < 3; diagonals++)
                {
                    if (Positions[0, 0] == player && Positions[1, 1] == player && Positions[2, 2] == player ||
                        Positions[0, 2] == player && Positions[1, 1] == player && Positions[2, 0] == player)
                    {
                        Console.WriteLine($"\nPlayer {c} WINS!!!!!!!!\n\nPress any key to play again!");
                        Console.ReadKey();
                        return 1;
                    }
                }

                return 0;
            }

        }
    }
}