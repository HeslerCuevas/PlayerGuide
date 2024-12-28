Console.Title = "Defense of Consolas";

Console.Write("Target Row: ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Target Column: ");
int column = Convert.ToInt32(Console.ReadLine());

Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($"Crew Member 1 at row {row}, column {column - 1}");
Console.WriteLine($"Crew Member 2 at row {row}, column {column + 1}");
Console.WriteLine($"Crew Member 3 at row {row - 1}, column {column}");
Console.WriteLine($"Crew Member 4 at row {row + 1}, column {column}");
Console.Beep();
