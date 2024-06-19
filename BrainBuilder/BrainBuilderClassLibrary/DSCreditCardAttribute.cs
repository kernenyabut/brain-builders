using DesertSandsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace BrainBuilderClassLibrary
{
    class DSCreditCardAttribute : ValidationAttribute
    {
        public DSCreditCardAttribute(string cardCodePropertyName)
        {
            CardCodePropertyName = cardCodePropertyName;
        }

        public string CardCodePropertyName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int cardLength = 0;
            string cardName = "";
            List<string> prefixes = new List<string>();
            bool hasPrefix = false;
            //Get value information of card code field
            PropertyInfo cardCodeInfo = validationContext.ObjectType.GetProperty(CardCodePropertyName);
            if (cardCodeInfo == null)
            {
                return new ValidationResult(String.Format(ErrorMessage, "Could not find a property named {0}", CardCodePropertyName));
            }

            var cardCode = cardCodeInfo.GetValue(validationContext.ObjectInstance);

            //Set card attributes for comparison and error reporting
            if (cardCode.ToString().Trim() == "AMEX")
            {
                prefixes = DSAddPrefixes(prefixes, "34", "37");
                cardLength = 15;
                cardName = "American Express";
            }
            else if (cardCode.ToString().Trim() == "MASTERCARD")
            {
                prefixes = DSAddPrefixes(prefixes, "51", "52", "53", "54", "55");
                cardLength = 16;
                cardName = "Mastercard";
            }
            else if (cardCode.ToString().Trim() == "VISA")
            {
                prefixes = DSAddPrefixes(prefixes, "4");
                cardLength = 16;
                cardName = "Visa";
            }

            //validate credit card
            if (value.ToString().Length != cardLength)
            {
                ErrorMessage = $"{cardName} cards must have {cardLength} numbers.";
            }
            else if (!DesertSandsValidation.DSIsNumeric(value.ToString()))
            {
                ErrorMessage = "Card numbers must be numerical";
            }
            else
            {
                foreach (string prefix in prefixes)
                {
                    if (value.ToString().Substring(0, prefix.Length) == prefix)
                    {
                        hasPrefix = true;
                        break;
                    }
                }
                if (!hasPrefix)
                {
                    ErrorMessage = $"{cardName} cards must have one of these prefixes: {prefixes}";
                }
            }

            if (ErrorMessage != null)
            {
                return new ValidationResult(string.Format(ErrorMessage, validationContext.DisplayName));
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        /// <summary>
        /// Adds prefixes of credit card to list for future comparison
        /// </summary>
        /// <param name="prefixes"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        List<string> DSAddPrefixes(List<string> prefixes, params string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                prefixes.Add(list[i]);
            }
            return prefixes;
        }
    }
}
