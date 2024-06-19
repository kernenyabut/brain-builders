using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class GameRecords
    {
        public GameRecords()
        {
            Achievements = new HashSet<Achievements>();
        }

        public int Id { get; set; }
        public int? AccountId { get; set; }
        public int? GameId { get; set; }
        public DateTime? DatePlayed { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Games Game { get; set; }
        public virtual ICollection<Achievements> Achievements { get; set; }
    }
}
