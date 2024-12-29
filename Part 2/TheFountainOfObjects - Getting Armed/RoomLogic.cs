namespace TheFountainOfProjectsProgramExtension
{
    public class RoomLogic
    {
        private readonly Game _game;
        public RoomLogic(Game game) { this._game = game; }

        public void CheckRoom()
        {
            if (_game.Player.Row == _game.FountainRow && _game.Player.Column == _game.FountainColumn && _game.Fountain == true)
            {
                ConsoleHelper.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!", ConsoleColor.Blue);
            }
            else if (_game.Player.Row == _game.FountainRow && _game.Player.Column == _game.FountainColumn)
            {
                ConsoleHelper.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Blue);
            }
            else if (_game.Player.Row == _game.EntranceRow && _game.Player.Column == _game.EntranceColumn && _game.Fountain == true)
            {
                ConsoleHelper.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!", ConsoleColor.Green);
                _game.End = true;
            }
            else if (_game.Player.Row == _game.EntranceRow && _game.Player.Column == _game.EntranceColumn)
            {
                Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
            }
        }
    }
}