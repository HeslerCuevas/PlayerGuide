namespace TheFountainOfProjectsProgramExtension
{
    public class Game
    {
        public Entity Player = new Entity();
        public int FountainRow; public int FountainColumn;
        public int EntranceRow; public int EntranceColumn;
        public bool Fountain;
        public bool End;
        private readonly Movement _movement;
        private readonly FountainLogic _fountainLogic;
        private RoomLogic _roomLogic;
        private GettingArmed _armed;

        public Game(int size, ref MonstersManager monstersManager)
        {
            End = false;
            _movement = new Movement(this, size);
            _fountainLogic = new FountainLogic(this);
            _roomLogic = new RoomLogic(this);
            Fountain = false;
            _armed = new GettingArmed(this, size, ref monstersManager.Monsters);

            switch (size)
            {
                case 4:
                    FountainRow = 0; FountainColumn = 2;
                    EntranceRow = 0; EntranceColumn = 0;
                    break;
                case 6:
                    FountainRow = 2; FountainColumn = 4;
                    EntranceRow = 5; EntranceColumn = 5;
                    break;
                case 8:
                    FountainRow = 4; FountainColumn = 3;
                    EntranceRow = 7; EntranceColumn = 1;
                    break;
            }

            Player.Row = EntranceRow;
            Player.Column = EntranceColumn;
        }

        public void EnableFountain() => _fountainLogic.EnableFountain();

        public void CheckRoom() => _roomLogic.CheckRoom();

        public void MoveEast() => _movement.MoveEast();
        public void MoveWest() => _movement.MoveWest();
        public void MoveSouth() => _movement.MoveSouth();
        public void MoveNorth() => _movement.MoveNorth();

        public void ShootEast() => _armed.ShootEast();
        public void ShootWest() => _armed.ShootWest();
        public void ShootSouth() => _armed.ShootSouth();
        public void ShootNorth() => _armed.ShootNorth();
    }
}