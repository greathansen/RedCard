using System;

namespace WebApp.Models
{
    public class Match : AbstractIdentificable
    {
        public DateTime Date { get; set; }
        public Team LocalTeam { get; set; }
        public Team VisitorTeam { get; set; }
        public int LocalGoals { get; set; }
        public int VisitorGoals { get; set; }
    }
}