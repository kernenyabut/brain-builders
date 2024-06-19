using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class Provinces
    {
        public Provinces()
        {
            Accounts = new HashSet<Accounts>();
            Profiles = new HashSet<Profiles>();
        }

        public string Code { get; set; }
        public string ProvinceName { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Profiles> Profiles { get; set; }
    }
}
