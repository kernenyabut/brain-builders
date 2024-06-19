using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class Games
    {
        public Games()
        {
            Achievements = new HashSet<Achievements>();
            GameStats = new HashSet<GameStats>();
        }

        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public int? TimesPlayed { get; set; }
        public DateTime? DatePublished { get; set; }

        public virtual ICollection<Achievements> Achievements { get; set; }
        public virtual ICollection<GameStats> GameStats { get; set; }
    }
}
