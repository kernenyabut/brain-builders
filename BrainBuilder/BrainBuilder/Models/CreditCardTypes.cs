using System;
using System.Collections.Generic;

namespace BrainBuilder.Models
{
    public partial class CreditCardTypes
    {
        public CreditCardTypes()
        {
            CreditCards = new HashSet<CreditCards>();
        }

        public string Code { get; set; }
        public string EnglishName { get; set; }
        public byte CardNumberLength { get; set; }
        public string CardNumberPrefixList { get; set; }

        public virtual ICollection<CreditCards> CreditCards { get; set; }
    }
}
