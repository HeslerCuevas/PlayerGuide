namespace TheFountainOfProjectsProgramExtension
{
    public record Proximity
    {
        public void CheckProximity(Game game, Pits pits, Amaroks amaroks, Maelstroms maelstroms)
        {
            pits.CheckProximity(game.Player.Row, game.Player.Column);
            maelstroms.CheckProximity(game.Player.Row, game.Player.Column);
            amaroks.CheckProximity(game.Player.Row, game.Player.Column);
        }
    }
}