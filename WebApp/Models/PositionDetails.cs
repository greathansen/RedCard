namespace WebApp.Models
{
    public class PositionDetails : AbstractIdentificable
    {
        public Team Team { get; set; }
        public int GoalsIn { get; set; }
        public int GoalsOut { get; set; }
        public int GameWon { get; set; }
        public int GameLost { get; set; }
        public int GameTie { get; set; }

    }
}