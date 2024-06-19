using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class Subscriptions
    {
        public Subscriptions()
        {
            UserSubscriptions = new HashSet<UserSubscriptions>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<UserSubscriptions> UserSubscriptions { get; set; }
    }
}
