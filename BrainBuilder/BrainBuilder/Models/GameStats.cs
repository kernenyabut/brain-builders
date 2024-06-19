using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class GameStats
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        public int? AccountId { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Games Game { get; set; }
        public virtual GameStatsMatching GameStatsMatching { get; set; }
    }
}
