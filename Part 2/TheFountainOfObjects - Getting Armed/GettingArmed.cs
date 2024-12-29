namespace TheFountainOfProjectsProgramExtension
{
    public class GettingArmed
    {
        private readonly Game _game;
        private readonly int _size;
        private Entity[] _monsters;
        private int _arrows;

        public GettingArmed(Game game, int size, ref Entity[] monsters)
        {
            this._game = game;
            this._size = size;
            this._monsters = monsters;
            _arrows = 4;
        }

        private void Shoot(int targetRow, int targetColumn)
        {
            if (_arrows <= 0)
            {
                ConsoleHelper.WriteLine("No arrows left!", ConsoleColor.Red);
                return;
            }

            _arrows--;
            bool hitSomething = false;

            ConsoleHelper.WriteLine($"Shooting at (Row={targetRow}, Column={targetColumn})", ConsoleColor.Gray);

            for (int i = 0; i < _monsters.Length; i++)
            {
                if (!_monsters[i].IsDefeated &&
                    _monsters[i].Row == targetRow &&
                    _monsters[i].Column == targetColumn)
                {
                    _monsters[i].IsDefeated = true;
                    hitSomething = true;
                    ConsoleHelper.WriteLine("You hear a roar of pain! You hit something!", ConsoleColor.Green);
                    break;
                }
            }

            if (!hitSomething)
            {
                ConsoleHelper.WriteLine("Your arrow whistles through empty air...", ConsoleColor.DarkYellow);
            }

            ConsoleHelper.WriteLine($"You have {_arrows} arrows remaining.", ConsoleColor.Cyan);
        }

        public void ShootNorth()
        {
            if (_game.Player.Row > 0)
            {
                Shoot(_game.Player.Row - 1, _game.Player.Column);
            }
            else if (_arrows <= 0)
            {
                ConsoleHelper.WriteLine("No arrows left!", ConsoleColor.Red);
                return;
            }
            else { Invalid(); }
        }

        public void ShootSouth()
        {
            if (_game.Player.Row < _size - 1)
            {
                Shoot(_game.Player.Row + 1, _game.Player.Column);
            }
            else if (_arrows <= 0)
            {
                ConsoleHelper.WriteLine("No arrows left!", ConsoleColor.Red);
                return;
            }
            else { Invalid(); }
        }

        public void ShootWest()
        {
            if (_game.Player.Column > 0)
            {
                Shoot(_game.Player.Row, _game.Player.Column - 1);
            }
            else if (_arrows <= 0)
            {
                ConsoleHelper.WriteLine("No arrows left!", ConsoleColor.Red);
                return;
            }
            else { Invalid(); }
        }

        public void ShootEast()
        {
            if (_game.Player.Column < _size - 1)
            {
                Shoot(_game.Player.Row, _game.Player.Column + 1);
            }
            else if (_arrows <= 0)
            {
                ConsoleHelper.WriteLine("No arrows left!", ConsoleColor.Red);
                return;
            }
            else { Invalid(); }
        }

        private void Invalid()
        {
            _arrows--;
            ConsoleHelper.WriteLine("You just shot into a wall...", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteLine($"You have {_arrows} arrows remaining.", ConsoleColor.Cyan);
        }
    }
}