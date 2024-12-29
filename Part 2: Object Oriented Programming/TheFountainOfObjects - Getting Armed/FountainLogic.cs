namespace TheFountainOfProjectsProgramExtension
{
    public class FountainLogic
    {
        private Game _game;
        public FountainLogic(Game game) { this._game = game; }

        public void EnableFountain()
        {
            if (_game.Player.Row == _game.FountainRow && _game.Player.Column == _game.FountainColumn)
            {
                _game.Fountain = true;
            }
            else if (_game.Fountain == true)
            {
                ConsoleHelper.WriteLine("The fountain is already activated! Escape now!", ConsoleColor.Blue);
            }
            else { ConsoleHelper.WriteLine("You can't enable the fountain here! cushh...", ConsoleColor.Red); }
        }
    }
}