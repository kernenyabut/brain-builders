using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class CreditCards
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string SecurityCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string CardCode { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual CreditCardTypes CardCodeNavigation { get; set; }
    }
}
