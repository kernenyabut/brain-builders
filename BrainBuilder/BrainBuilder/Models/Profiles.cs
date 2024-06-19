using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class Profiles
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string Motto { get; set; }
        public string ProvinceCode { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? PromotionalEmails { get; set; }
        public bool? IsSubscribed { get; set; }

        public virtual Accounts IdNavigation { get; set; }
        public virtual Provinces ProvinceCodeNavigation { get; set; }
    }
}
