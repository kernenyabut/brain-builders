using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            CreditCards = new HashSet<CreditCards>();
            GameStats = new HashSet<GameStats>();
            GameStatsMatching = new HashSet<GameStatsMatching>();
            UserSubscriptions = new HashSet<UserSubscriptions>();
        }

        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string ProvinceCode { get; set; }

        public virtual Provinces ProvinceCodeNavigation { get; set; }
        public virtual Achievements Achievements { get; set; }
        public virtual Avatars Avatars { get; set; }
        public virtual Profiles Profiles { get; set; }
        public virtual ICollection<CreditCards> CreditCards { get; set; }
        public virtual ICollection<GameStats> GameStats { get; set; }
        public virtual ICollection<GameStatsMatching> GameStatsMatching { get; set; }
        public virtual ICollection<UserSubscriptions> UserSubscriptions { get; set; }
    }
}
