using System.Reflection.Metadata.Ecma335;

namespace TheOldRobotProgram
{
    public class RuntimeProgram
    {
        public static void Main()
        {
            bool stop = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Robot robot = new();
            Console.WriteLine("Enter robot commands (on, off, north, south, east, west): ");

            do
            {
                Console.Write($"Enter command {robot.Commands.Count + 1}: ");
                string commandInput = Console.ReadLine()?.ToLower();

                RobotCommand? command = commandInput switch
                {
                    "on" => new RobotCommand.OnCommand(),
                    "off" => new RobotCommand.OffCommand(),
                    "north" => new RobotCommand.NorthCommand(),
                    "south" => new RobotCommand.SouthCommand(),
                    "east" => new RobotCommand.EastCommand(),
                    "west" => new RobotCommand.WestCommand(),
                    _ => null
                };

                if (command != null)
                {
                    robot.Commands.Add(command);
                }
                else if (commandInput == "stop")
                {
                    stop = true;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"Invalid command: {commandInput}. Skipping.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            while (!stop);

            robot.Run();
            Console.ReadKey();
        }
        public class Robot
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsPowered { get; set; }
            public List<RobotCommand> Commands { get; } = new List<RobotCommand>();
            public virtual void Run()
            {
                foreach (RobotCommand? command in Commands)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    command?.Run(this);
                    Console.WriteLine($"[{X} {Y} {IsPowered}]");
                    Console.ResetColor();
                }
            }   
        }

        public abstract class RobotCommand
        {
            public abstract void Run(Robot robot);

            public class OnCommand : RobotCommand
            {
                public override void Run(Robot robot)
                {
                    robot.IsPowered = true;
                }
            }

            public class OffCommand : RobotCommand
            {
                public override void Run(Robot robot)
                {
                    robot.IsPowered = false;
                }
            }

            public class NorthCommand : RobotCommand
            {
                public override void Run(Robot robot)
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

            public class SouthCommand : RobotCommand
            {
                public override void Run(Robot robot)
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

            public class WestCommand : RobotCommand
            {
                public override void Run(Robot robot)
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

            public class EastCommand : RobotCommand
            {
                public override void Run(Robot robot)
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