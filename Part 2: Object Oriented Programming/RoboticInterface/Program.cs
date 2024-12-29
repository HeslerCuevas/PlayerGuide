namespace RoboticInterfaceProgram
{
    public class RuntimeProgram
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Robot robot = new();
            Console.WriteLine("Enter 3 robot commands (on, off, north, south, east, west): ");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter command {i + 1}: ");
                string? commandInput = Console.ReadLine()?.ToLower();

                IRobotCommand? command = commandInput switch
                {
                    "on" => new IRobotCommand.OnCommand(),
                    "off" => new IRobotCommand.OffCommand(),
                    "north" => new IRobotCommand.NorthCommand(),
                    "south" => new IRobotCommand.SouthCommand(),
                    "east" => new IRobotCommand.EastCommand(),
                    "west" => new IRobotCommand.WestCommand(),
                    _ => null  // Invalid command
                };

                if (command != null)
                {
                    robot.Commands[i] = command;
                }
                else
                {
                    Console.WriteLine($"Invalid command: {commandInput}. Skipping.");
                    i--; // Decrement to retry this slot
                }
            }

            robot.Run();
            Console.ReadKey();
        }
        public class Robot
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsPowered { get; set; }
            public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
            public virtual void Run()
            {
                foreach (IRobotCommand? command in Commands)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    command?.Run(this);
                    Console.WriteLine($"[{X} {Y} {IsPowered}]");
                    Console.ResetColor();
                }
            }
        }

        public interface IRobotCommand
        {
            void Run(Robot robot);

            public class OnCommand : IRobotCommand
            {
                public void Run(Robot robot)
                {
                    robot.IsPowered = true;
                }
            }

            public class OffCommand : IRobotCommand
            {
                public void Run(Robot robot)
                {
                    robot.IsPowered = false;
                }
            }

            public class NorthCommand : IRobotCommand
            {
                public void Run(Robot robot)
                {
                    if (robot.IsPowered)
                    {
                        robot.Y += 1;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour robot is OFF!, Please turn on before moving!\n");
                        Console.ResetColor();
                    }
                }
            }

            public class SouthCommand : IRobotCommand
            {
                public void Run(Robot robot)
                {
                    if (robot.IsPowered)
                    {
                        robot.Y -= 1;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour robot is OFF!, Please turn on before moving!\n");
                        Console.ResetColor();
                    }
                }
            }

            public class WestCommand : IRobotCommand
            {
                public void Run(Robot robot)
                {
                    if (robot.IsPowered)
                    {
                        robot.X -= 1;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour robot is OFF!, Please turn on before moving!\n");
                        Console.ResetColor();
                    }
                }
            }

            public class EastCommand : IRobotCommand
            {
                public void Run(Robot robot)
                {
                    if (robot.IsPowered)
                    {
                        robot.X += 1;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYour robot is OFF!, Please turn on before moving!\n");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}