using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class GameStatsMatching
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public int? TimeTaken { get; set; }
        public int? MovesTaken { get; set; }
        public int? FinalScore { get; set; }
        public DateTime? Date { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual GameStats IdNavigation { get; set; }
    }
}
