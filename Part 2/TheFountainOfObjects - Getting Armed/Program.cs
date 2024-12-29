using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System;

namespace TheFountainOfProjectsProgramExtension
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHelper.WriteLine("Welcome to the Fountain of Objects...", ConsoleColor.Blue);
            Size gameSize = new();
            int size = gameSize.GetGameSize();
            Commands playerCommands = new();
            Status status = new();
            End end = new();
            Proximity proximity = new();
            Pits pit = new Pits(size);
            Maelstroms maelstrom = new(size);
            Amaroks amaroks = new(size);
            MonstersManager monsters = new(size, ref amaroks.Locations, ref maelstrom.Locations);
            Game game = new(size, ref monsters);
            DateTime start = DateTime.Now;
                
            do
            {
                status.DisplayStatus(game);

                maelstrom.MaelstromEffect(ref game.Player.Row, ref game.Player.Column, size);

                if (pit.CheckEncounter(game.Player.Row, game.Player.Column)) { game.End = true; }
                else if (amaroks.CheckEncounter(game.Player.Row, game.Player.Column)) { game.End = true; }

                game.CheckRoom();
                if (game.End) { end.EndGame(game, start); break; }

                proximity.CheckProximity(game, pit, amaroks, maelstrom);

                playerCommands.Execute(game);
            }
            while (!game.End);
        }
    }
}
    public class Entity
    {
        public int Column;
        public int Row;
        public bool IsDefeated { get; set; }
    }
