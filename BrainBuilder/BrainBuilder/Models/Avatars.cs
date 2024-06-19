using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class Avatars
    {
        public int Id { get; set; }
        public string AvatarCode { get; set; }

        public virtual Accounts IdNavigation { get; set; }
    }
}
