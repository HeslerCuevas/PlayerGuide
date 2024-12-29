namespace TheFountainOfProjectsProgramExtension
{
    public class MonstersManager
    {
        public Entity[] Monsters;

        public MonstersManager(int size, ref Entity[] amaroks, ref Entity[] maelstroms)
        {
            Monsters = new Entity[amaroks.Length + maelstroms.Length];
            int index = 0;

            for (int i = 0; i < amaroks.Length; i++)
            {
                Monsters[index] = amaroks[i];
                index++;
            }

            for (int i = 0; i < maelstroms.Length; i++)
            {
                Monsters[index] = maelstroms[i];
                index++;
            }
        }
    }
}