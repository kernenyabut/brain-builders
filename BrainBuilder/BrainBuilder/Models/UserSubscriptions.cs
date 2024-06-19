using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class UserSubscriptions
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string SubscriptionCode { get; set; }
        public string BillingTypeCode { get; set; }
        public DateTime? InitalPaymentDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? PaymentDue { get; set; }
        public bool IsActive { get; set; }
        public bool IsFreeTrial { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual BillingType BillingTypeCodeNavigation { get; set; }
        public virtual Subscriptions SubscriptionCodeNavigation { get; set; }
    }
}
