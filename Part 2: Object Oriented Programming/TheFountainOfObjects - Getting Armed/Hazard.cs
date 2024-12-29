namespace TheFountainOfProjectsProgramExtension
{
    public abstract class Hazard
    {
        public Entity[] Locations = new Entity[10];
        private readonly string _proximityMessage;
        private readonly string _encounterMessage;

        protected Hazard(int count, string proximityMessage, string encounterMessage)
        {
            Locations = new Entity[count];
            this._proximityMessage = proximityMessage;
            this._encounterMessage = encounterMessage;
        }

        public bool CheckEncounter(int playerRow, int playerColumn)
        {
            foreach (var location in Locations)
            {
                if (location.Row == playerRow && location.Column == playerColumn && !location.IsDefeated)
                {
                    ConsoleHelper.WriteLine(_encounterMessage, ConsoleColor.Red);
                    return true;
                }
            }
            return false;
        }

        public void CheckProximity(int playerRow, int playerColumn)
        {
            foreach (var location in Locations)
            {
                if (!location.IsDefeated && Math.Abs(location.Row - playerRow) <= 1 && Math.Abs(location.Column - playerColumn) <= 1 && !location.IsDefeated)
                {
                    ConsoleHelper.WriteLine(_proximityMessage, ConsoleColor.Magenta);
                    break;
                }
            }
        }
    }
}