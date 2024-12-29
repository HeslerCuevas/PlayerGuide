Console.WriteLine("Eggs gathered: ");
var eggs_gathered = Console.ReadLine();
var eggsForSisters = Convert.ToInt32(eggs_gathered) / 4;
var eggsForDuckbear = Convert.ToInt32(eggs_gathered) % 4;
Console.WriteLine("Eggs for sisters: " + eggsForSisters + ", eggs for Duckbear: " + eggsForDuckbear);
