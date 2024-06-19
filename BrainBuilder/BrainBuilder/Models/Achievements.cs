using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class Achievements
    {
        public int Id { get; set; }
        public int? GameId { get; set; }
        public DateTime? DatePlayed { get; set; }

        public virtual Games Game { get; set; }
        public virtual Accounts IdNavigation { get; set; }
    }
}
