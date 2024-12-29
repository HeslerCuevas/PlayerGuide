namespace TheFountainOfProjectsProgramExtension
{
    public class Movement
    {
        private Game _game;
        private readonly int _size;

        public Movement(Game game, int size)
        {
            this._game = game;
            this._size = size;
        }

        public void MoveEast()
        {
            if (_game.Player.Column + 1 < _size)
            {
                _game.Player.Column++;
            }
            else { Invalid(); }
        }

        public void MoveWest()
        {
            if (_game.Player.Column - 1 < _size && _game.Player.Column > 0)
            {
                _game.Player.Column--;
            }
            else { Invalid(); }
        }

        public void MoveSouth()
        {
            if (_game.Player.Row + 1 < _size)
            {
                _game.Player.Row++;
            }
            else { Invalid(); }
        }

        public void MoveNorth()
        {
            if (_game.Player.Row - 1 < _size && _game.Player.Row > 0)
            {
                _game.Player.Row--;
            }
            else { Invalid(); }
        }

        private void Invalid()
        {
            ConsoleHelper.WriteLine("You can't move there! Cushhh... That room doesn't even exist.", ConsoleColor.Red);
        }
    }
}