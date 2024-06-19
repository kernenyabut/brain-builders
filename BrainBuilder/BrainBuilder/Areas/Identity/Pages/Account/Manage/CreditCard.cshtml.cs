using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BrainBuilder.Models;
using DesertSandsClassLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BrainBuilder.Areas.Identity.Pages.Account.Manage
{
    public class CreditCardModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly BrainBuilderDBContext _context;


        public CreditCardModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender,
            BrainBuilderDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public partial class InputModel
        {
            public int? AccountId { get; set; }

            //[Required]
            [Display(Name = "Card Number")]
            public string CardNumber { get; set; }

            //[Required]
            [Display(Name = "Expiry Date (MM/YYYY)")]
            public string ExpiryMonth { get; set; }

            //[Required]
            [Display(Name = "Expiry Date (MM/YYYY)")]
            public string ExpiryYear { get; set; }

            //[Required]
            [Display(Name = "Security Code")]
            public string SecurityCode { get; set; }

            //[Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            //[Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            //[Required]
            [Display(Name = "Billing Address")]
            public string Address { get; set; }
            [Display(Name = "Billing Address Line 2")]
            public string Address2 { get; set; }

            [Display(Name = "Province")]
            public string Province { get; set; }

            //[Required]
            [Display(Name = "City")]
            public string City { get; set; }

            [Display(Name = "Postal Code")]
            public string PostalCode { get; set; }

            //[Required]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            //[Required]
            [Display(Name = "Card Type")]
            public string CardCode { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            //provide data to select lists
            ViewData["CardType"] = new SelectList(_context.CreditCardTypes, "Code", "EnglishName");
            ViewData["Provinces"] = new SelectList(_context.Provinces, "Code", "ProvinceName");
            ViewData["Months"] = DSFillMonthSelectList();
            ViewData["Years"] = DSFillYearSelectList(DateTime.Now.Year.ToString());
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            else
            {
                //get Id of current user
                Accounts accounts = _context.Accounts.Where(p => p.Username == user.UserName).FirstOrDefault();
                if (accounts != null)
                {
                    Input.AccountId = accounts.AccountId;
                }
                else
                {
                    return NotFound($"Unable to find person associated to '{user.UserName}'/'s account.");
                }
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var card = new CreditCards
                    {
                        AccountId = Input.AccountId,
                        CardNumber = Input.CardNumber,
                        SecurityCode = Input.SecurityCode,
                        CardCode = Input.CardCode,
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        Address = Input.Address,
                        Address2 = Input.Address2,
                        City = Input.City,
                        Province = Input.Province,
                        PostalCode = Input.PostalCode,
                        PhoneNumber = Input.PhoneNumber,
                        ExpiryMonth = Input.ExpiryMonth,
                        ExpiryYear = Input.ExpiryYear
                    };

                    _context.Add(card);
                    TempData["Message"] = "Credit Card successfully inserted.";
                    await _context.SaveChangesAsync();
                    StatusMessage = "Credit Card Information Added";
                    return RedirectToPage();
                }
                StatusMessage = "An error has occured, please try again.";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.GetBaseException().Message);
            }
            //provide dropdowns with default value from previous input
            ViewData["CardType"] = new SelectList(_context.CreditCardTypes, "Code", "EnglishName", Input.CardCode);
            ViewData["Provinces"] = new SelectList(_context.Provinces, "Code", "ProvinceName");
            ViewData["Months"] = DSFillMonthSelectList(Input.ExpiryMonth);
            ViewData["Years"] = DSFillYearSelectList(Input.ExpiryYear);
            return Page();
        }

        /// <summary>
        /// Fills a selectlist with the next 4 years
        /// </summary>
        /// <returns></returns>
        public SelectList DSFillYearSelectList(string input)
        {
            List<string> years = new List<string>();

            for (int i = 0; i <= 4; i++)
            {
                years.Add((DateTime.Now.Year + i).ToString());
            }

            return new SelectList(years, input);
        }

        /// <summary>
        /// Fills a selectlist with all the months in a year
        /// </summary>
        /// <returns></returns>
        public SelectList DSFillMonthSelectList(string input = "01")
        {
            List<string> months = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                string month = i.ToString();
                if (month.Length == 1)
                    month = month.PadLeft(2, '0');
                months.Add(month);
            }

            return new SelectList(months, input);
        }


        //Server Side Validation
        public partial class InputModel : IValidatableObject
        {
            BrainBuilderDBContext _brainBuilderDBcontext = new BrainBuilderDBContext();

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                CreditCardTypes creditCard = _brainBuilderDBcontext.CreditCardTypes.Where(c => c.Code == CardCode).FirstOrDefault();
                Accounts account = _brainBuilderDBcontext.Accounts.Where(c => c.AccountId == AccountId).FirstOrDefault();
                int cardNumberLength = creditCard.CardNumberLength;
                string[] prefixList = creditCard.CardNumberPrefixList.Split(',');
                string prefixes = "";

                for (int i = 0; i < prefixList.Length; i++)
                {
                    prefixList[i] = DesertSandsValidation.DSKeepNumeric(prefixList[i]);
                    if (i == 0)
                        prefixes += prefixList[i];
                    else
                        prefixes += ", " + prefixList[i];
                }

                bool hasPrefix = false;

                //If card number is empty
                if (CardNumber == null || CardNumber.Trim() == "")
                {
                    yield return new ValidationResult("Card number cannot be empty", new[] { nameof(CardNumber) });
                }
                else
                {
                    CardNumber = DesertSandsValidation.DSKeepNumeric(CardNumber);

                    //If card is not a required length
                    if (CardNumber.Length != cardNumberLength)
                    {
                        yield return new ValidationResult(creditCard.EnglishName + " cards must have " + cardNumberLength + " numbers.", new[] { nameof(CardNumber) });
                    }

                    //Checks if the credit card is already in use by the account
                    else if (_brainBuilderDBcontext.CreditCards
                        .Where(c => c.CardNumber == CardNumber)
                        .Where(c => c.AccountId == AccountId)
                        .FirstOrDefault() != null)
                    {
                        yield return new ValidationResult("Card already in use by this account", new[] { nameof(CardNumber) });
                    }

                    //Checks if card has right prefix
                    else
                    {
                        foreach (string prefix in prefixList)
                        {
                            if (CardNumber.Substring(0, prefix.Length) == prefix)
                            {
                                hasPrefix = true;
                                break;
                            }
                        }
                        if (!hasPrefix)
                        {
                            yield return new ValidationResult(creditCard.EnglishName + " cards must have one of these prefixes: " + prefixes, new[] { nameof(CardNumber) });
                        }
                    }
                }

                if (SecurityCode == null || SecurityCode.Trim() == "")
                {
                    yield return new ValidationResult("Security Code cannot be blank", new[] { nameof(SecurityCode) });
                }
                else if (!DesertSandsValidation.DSIsNumeric(SecurityCode))
                {
                    yield return new ValidationResult("Security Code must be a number", new[] { nameof(SecurityCode) });
                }
                else if (SecurityCode.Length < 3 || SecurityCode.Length > 3)
                {
                    yield return new ValidationResult("Security Code be 3 digits", new[] { nameof(SecurityCode) });
                }

                if (FirstName == null || FirstName.Trim() == "")
                {
                    yield return new ValidationResult("First name cannot be empty", new[] { nameof(FirstName) });
                }
                else
                {
                    FirstName = FirstName.Trim();
                    FirstName = DesertSandsValidation.DSCapitalize(FirstName);
                }

                if (LastName == null || LastName.Trim() == "")
                {
                    yield return new ValidationResult("Last name cannot be empty", new[] { nameof(LastName) });
                }
                else
                {
                    LastName = LastName.Trim();
                    LastName = DesertSandsValidation.DSCapitalize(LastName);
                }

                if (Address == null || Address.Trim() == "")
                {
                    yield return new ValidationResult("Billing Address cannot be empty", new[] { nameof(Address) });
                }
                else
                {
                    Address = Address.Trim();
                    if (!DesertSandsValidation.DSIsAddress(Address))
                    {
                        yield return new ValidationResult("Street address must be a valid address", new[] { nameof(Address) });
                    }
                    else
                    {
                        Address = DesertSandsValidation.DSCapitalize(Address);
                    }
                }

                if (PostalCode == null || PostalCode.Trim() == "")
                {
                    yield return new ValidationResult("Postal Code cannot be left blank", new[] { nameof(PostalCode) });
                }
                else 
                {
                    PostalCode = PostalCode.Trim();
                    //do Canadian postal code validation
                    if (!DesertSandsValidation.DSPostalCodeValidation(PostalCode))
                    {
                        yield return new ValidationResult("Postal code is in the wrong format", new[] { nameof(PostalCode) });
                    }
                    else
                    {
                        PostalCode = DesertSandsValidation.DSPostalCodeFormat(PostalCode);
                    }
                }
                if (City == null || City.Trim() == "")
                {
                    yield return new ValidationResult("City cannot be left blank", new[] { nameof(City) });
                }
                else
                {
                    City = City.Trim();
                    City = DesertSandsValidation.DSCapitalize(City);
                }

                if (PhoneNumber == null || PhoneNumber.Trim() == "")
                {
                    yield return new ValidationResult("Phone number cannot be left blank", new[] { nameof(PhoneNumber) });
                }
                else
                {
                    if (!DesertSandsValidation.DSPhoneValidation(PhoneNumber))
                    {
                        yield return new ValidationResult("Phone number must have a valid format. EX. (###)-###-####", new[] { nameof(PhoneNumber) });

                    }
                    else
                    {
                        PhoneNumber = DesertSandsValidation.DSKeepNumeric(PhoneNumber);
                        PhoneNumber = DesertSandsValidation.DSPhoneFormat(PhoneNumber);
                    }
                }

                yield return ValidationResult.Success;
            }
        }
    }
}