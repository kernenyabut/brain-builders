using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class BillingType
    {
        public BillingType()
        {
            UserSubscriptions = new HashSet<UserSubscriptions>();
        }

        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserSubscriptions> UserSubscriptions { get; set; }
    }
}
