using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrainBuilder.Models;
using DesertSandsClassLibrary;
using System.ComponentModel.DataAnnotations;

/*
 ********
 * Subscriptions Controller
 * Controller used for subscription
 * Date Created: 03/21/2021
 * Desert Sands 
 *********
*/

namespace BrainBuilder.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly BrainBuilderDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public SubscriptionsController(BrainBuilderDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public partial class InputModel
        {
            public string BillingType { get; set; }

            public string BillingTypeName { get; set; }

            public string Subscription { get; set; }

            public string SubscriptionName { get; set; }

            public int AccountId { get; set; }

            [Display(Name = "Credit Cards")]
            public string CardNumber { get; set; }

            public Accounts Account { get; set; }

            [Display(Name = "Security Code")]
            public string SecurityCode { get; set; }

            [Display(Name = "Total Cost")]
            public decimal Price { get; set; }

        }

        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
            //Checks if user is authenticated to determine if the subscription page recommends the user making an account
            if (User.Identity.IsAuthenticated)
            {
                //Gets id of current user
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                //Gets information of the correct person
                var profile = await _context.Profiles
                    .Include(p => p.ProvinceCodeNavigation)
                    .FirstOrDefaultAsync(p => p.Id == account.AccountId);

                //Determines if the user has a subscription
                if (profile.IsSubscribed == true)
                {
                    //Gets correct subscription
                    var subscription = await _context.UserSubscriptions
                        .FirstOrDefaultAsync(p => p.AccountId == account.AccountId);

                    //If the free trial of the subscription already has ended
                    if (subscription.IsFreeTrial)
                    {
                        ViewData["trialEnded"] = "TrialActive";
                    }
                    else
                    {
                        ViewData["trialEnded"] = "TrialInactive";
                    }

                    //If the subscription is inactive
                    if (subscription.IsActive)
                    {
                        ViewData["isActive"] = "MembershipActive";
                    }
                    else
                    {
                        ViewData["isActive"] = "MembershipInactive";
                    }

                    ViewData["subscription"] = "MembershipPlus";
                }
                else
                {
                    ViewData["subscription"] = "Membership";
                    ViewData["isActive"] = "MembershipInactive";
                    ViewData["trialEnded"] = "TrialInactive";
                }

            }

            else
            {
                ViewData["subscription"] = "None";
                ViewData["trialEnded"] = "TrialInactive";
                ViewData["isActive"] = "MembershipInactive";
            }

            //Gets correct subscription billing
            var annualBilling = await _context.BillingType
                .FirstOrDefaultAsync(p => p.Code == "AN");
            var monthlyBilling = await _context.BillingType
                .FirstOrDefaultAsync(p => p.Code == "MN");

            //Gets subscription codes
            var membershipPlus = await _context.Subscriptions
                .FirstOrDefaultAsync(p => p.Code == "MP");

            //Adds subscription codes
            ViewData["AnnualBilling"] = annualBilling.Code;
            ViewData["MonthlyBilling"] = monthlyBilling.Code;
            ViewData["MembershipPlus"] = membershipPlus.Code;

            return View(await _context.Subscriptions.ToListAsync());
        }

        // GET: Subscriptions/Details/5
        [Authorize]
        public async Task<IActionResult> Details(string code, string billingType)
        {
            //Checks if user is authenticated and they already have a paid membership
            if (User.Identity.IsAuthenticated)
            {
                //Gets id of current user
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                //Gets information of the correct person
                var profile = await _context.Profiles
                    .Include(p => p.ProvinceCodeNavigation)
                    .FirstOrDefaultAsync(p => p.Id == account.AccountId);

                if (profile.IsSubscribed == false || profile.IsSubscribed == null)
                {
                    //Validates subscription
                    if (code == null || billingType == null)
                    {
                        TempData["message"] = "Subscripton was invalid";
                        return RedirectToAction("Index", "Subscriptions");
                    }

                    var subscriptions = await _context.Subscriptions
                        .FirstOrDefaultAsync(m => m.Code == code);
                    var billingTypes = await _context.BillingType
                        .FirstOrDefaultAsync(m => m.Code == billingType);

                    if (subscriptions == null || billingTypes == null)
                    {
                        TempData["Message"] = "Subscripton was invalid";
                        return RedirectToAction("Index", "Subscriptions");
                    }

                    Accounts accounts = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();
                    List<CreditCards> creditCards = _context.CreditCards.Where(c => c.AccountId.Equals(accounts.AccountId)).ToList();
                    ViewData["CreditCardSize"] = creditCards.Count();
                    ViewData["CreditCard"] = new SelectList(creditCards, "CardNumber", "CardNumber");
                    decimal subscriptionPrice = Convert.ToDecimal(subscriptions.Price);

                    InputModel inputModel = new InputModel();

                    //If billing is annually - multiply by twelve months
                    if (billingType == "AN")
                    {
                        subscriptionPrice *= 12;
                    }

                    //Inserts into input model
                    inputModel.BillingType = billingType;
                    inputModel.BillingTypeName = billingTypes.Name;
                    inputModel.AccountId = accounts.AccountId;
                    inputModel.Price = subscriptionPrice;
                    inputModel.Account = accounts;
                    inputModel.Subscription = code;
                    inputModel.SubscriptionName = subscriptions.Name;

                    return View(inputModel);
                }
                else
                {
                    return RedirectToAction("Index", "Subscriptions");
                }
            }
            else
            {
                return RedirectToAction("Index", "Subscriptions");
            }
        }

        // GET: Subscriptions/Details/5
        //For reactivating subscription
        [Authorize]
        public async Task<IActionResult> Deactivate()
        {
            //Checks if user is authenticated and they already have a paid membership
            if (User.Identity.IsAuthenticated)
            {
                //Gets id of current user
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                //Gets information of the correct person
                var profile = await _context.Profiles
                    .Include(p => p.ProvinceCodeNavigation)
                    .FirstOrDefaultAsync(p => p.Id == account.AccountId);

                if (profile.IsSubscribed == true || profile.IsSubscribed == null)
                {
                    Accounts accounts = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();
                    UserSubscriptions userSubscriptions = _context.UserSubscriptions.Where(u => u.AccountId == accounts.AccountId).FirstOrDefault();
                    Subscriptions subscriptions = _context.Subscriptions.Where(u => u.Code == userSubscriptions.SubscriptionCode).FirstOrDefault();
                    BillingType billingType = _context.BillingType.Where(u => u.Code == userSubscriptions.BillingTypeCode).FirstOrDefault();
                    decimal subscriptionPrice = Convert.ToDecimal(subscriptions.Price);

                    InputModel inputModel = new InputModel();

                    //If billing is annually - multiply by twelve months
                    if (userSubscriptions.BillingTypeCode == "AN")
                    {
                        subscriptionPrice *= 12;
                    }

                    //Inserts into input model
                    inputModel.BillingType = billingType.Code;
                    inputModel.BillingTypeName = billingType.Name;
                    inputModel.AccountId = accounts.AccountId;
                    inputModel.Price = subscriptionPrice;
                    inputModel.Account = accounts;
                    inputModel.Subscription = subscriptions.Code;
                    inputModel.SubscriptionName = subscriptions.Name;

                    return View("Deactivate", inputModel);
                }
                else
                {
                    return RedirectToAction("Index", "Subscriptions");
                }
            }
            else
            {
                return RedirectToAction("Index", "Subscriptions");
            }
        }

        /// <summary>
        /// Reactivates subscription
        /// </summary>
        /// <param name="value"></param>
        /// <param name="billing"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Reactivate(string value, string billing)
        {
            //Checks if user is authenticated and they already have a paid membership
            if (User.Identity.IsAuthenticated)
            {
                //Gets id of current user
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                //Gets information of the correct person
                var profile = await _context.Profiles
                    .Include(p => p.ProvinceCodeNavigation)
                    .FirstOrDefaultAsync(p => p.Id == account.AccountId);

                if (profile.IsSubscribed == true || profile.IsSubscribed == null)
                {
                    Accounts accounts = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();
                    UserSubscriptions userSubscriptions = _context.UserSubscriptions.Where(u => u.AccountId == accounts.AccountId).FirstOrDefault();
                    Subscriptions subscriptions = _context.Subscriptions.Where(u => u.Code == userSubscriptions.SubscriptionCode).FirstOrDefault();
                    BillingType billingType = _context.BillingType.Where(u => u.Code == billing).FirstOrDefault();
                    decimal subscriptionPrice = Convert.ToDecimal(subscriptions.Price);

                    //Credit card
                    List<CreditCards> creditCards = _context.CreditCards.Where(c => c.AccountId.Equals(accounts.AccountId)).ToList();
                    ViewData["CreditCardSize"] = creditCards.Count();
                    ViewData["CreditCard"] = new SelectList(creditCards, "CardNumber", "CardNumber");

                    InputModel inputModel = new InputModel();

                    //If billing is annually - multiply by twelve months
                    if (userSubscriptions.BillingTypeCode == "AN")
                    {
                        subscriptionPrice *= 12;
                    }

                    //Inserts into input model
                    inputModel.BillingType = billingType.Code;
                    inputModel.BillingTypeName = billingType.Name;
                    inputModel.AccountId = accounts.AccountId;
                    inputModel.Price = subscriptionPrice;
                    inputModel.Account = accounts;
                    inputModel.Subscription = subscriptions.Code;
                    inputModel.SubscriptionName = subscriptions.Name;

                    ViewData["Action"] = value;

                    return View("Reactivate", inputModel);
                }
                else
                {
                    return RedirectToAction("Index", "Subscriptions");
                }
            }
            else
            {
                return RedirectToAction("Index", "Subscriptions");
            }
        }


        //Makes a purchase 
        [Authorize]
        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(InputModel input)
        {
            if (ModelState.IsValid)
            {
                //Activate subscription 
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                //Adds log to user subscriptions table
                var intialPurchaseDate = new DateTime();
                intialPurchaseDate = DateTime.Now;
                var paymentDue = new DateTime(intialPurchaseDate.Year, intialPurchaseDate.Month, 1);

                var userSubscription = new UserSubscriptions {
                    //Id = account.AccountId,
                    AccountId = account.AccountId,
                    SubscriptionCode = input.Subscription,
                    BillingTypeCode = input.BillingType,
                    InitalPaymentDate = intialPurchaseDate,
                    PaymentDate = intialPurchaseDate,
                    PaymentDue = paymentDue,
                    IsFreeTrial = true,
                    IsActive = true
                };
                _context.Add(userSubscription);
                await _context.SaveChangesAsync();

                //Changes profile to active
                Profiles profile = _context.Profiles.Where(p => p.Id == account.AccountId).FirstOrDefault();
                profile.IsSubscribed = true;

                _context.Update(profile);
                TempData["Message"] = "Purchase made successfully.";
                //StatusMessage = "An error has occured, please try again.";
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Subscriptions");
            }
            Accounts accounts = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();
            List<CreditCards> creditCards = _context.CreditCards.Where(c => c.AccountId.Equals(accounts.AccountId)).ToList();
            ViewData["CreditCard"] = new SelectList(_context.CreditCards.Where(c => c.AccountId.Equals(accounts.AccountId)), "CardNumber", "CardNumber", Input.CardNumber);
            ViewData["CreditCardSize"] = creditCards.Count();
            return View(Input);
        }

        //Deactivates subscription
        [Authorize]
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateSubscription()
        {
            //Deactivate subscription 
            Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

            //Adds log to user subscriptions table
            var intialPurchaseDate = new DateTime();
            intialPurchaseDate = DateTime.Now;
            var paymentDue = new DateTime(intialPurchaseDate.Year, intialPurchaseDate.Month, 1);

            //Updates to inactive
            UserSubscriptions userSubscription = _context.UserSubscriptions.Where(u => u.AccountId == account.AccountId).FirstOrDefault();
            userSubscription.IsActive = false;

            _context.Update(userSubscription);

            //Changes profile to inactive
            //Profiles profile = _context.Profiles.Where(p => p.Id == account.AccountId).FirstOrDefault();
            //profile.IsSubscribed = false;

            //_context.Update(profile);
            TempData["message"] = "Subscription has been deactivated.";
            //StatusMessage = "An error has occured, please try again.";
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Subscriptions");
        }

        //Makes a purchase 
        [Authorize]
        [HttpPost, ActionName("Reactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reactivate(InputModel input)
        {
            if (ModelState.IsValid)
            {
                //Activate subscription 
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                //Adds log to user subscriptions table
                var intialPurchaseDate = new DateTime();
                intialPurchaseDate = DateTime.Now;
                var paymentDue = new DateTime(intialPurchaseDate.Year, intialPurchaseDate.Month, 1);

                //Updates to inactive
                UserSubscriptions userSubscription = _context.UserSubscriptions.Where(u => u.AccountId == account.AccountId).FirstOrDefault();
                userSubscription.IsActive = true;

                _context.Update(userSubscription);

                //Changes profile to active
                //Profiles profile = _context.Profiles.Where(p => p.Id == account.AccountId).FirstOrDefault();
                //profile.IsSubscribed = true;

                //_context.Update(profile);
                TempData["message"] = "Activation made successfully.";
                //StatusMessage = "An error has occured, please try again.";
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Subscriptions");
            }
            Accounts accounts = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();
            List<CreditCards> creditCards = _context.CreditCards.Where(c => c.AccountId.Equals(accounts.AccountId)).ToList();
            ViewData["CreditCard"] = new SelectList(_context.CreditCards.Where(c => c.AccountId.Equals(accounts.AccountId)), "CardNumber", "CardNumber", Input.CardNumber);
            ViewData["CreditCardSize"] = creditCards.Count();
            return View(Input);
        }

        private bool SubscriptionsExists(string id)
        {
            return _context.Subscriptions.Any(e => e.Code == id);
        }

        //Server Side Validation
        public partial class InputModel : IValidatableObject
        {
            BrainBuilderDBContext _brainBuilderDBContext = new BrainBuilderDBContext();

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                CreditCards creditCard = _brainBuilderDBContext.CreditCards.Where(c => c.CardNumber == CardNumber).FirstOrDefault();


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
                else if (SecurityCode != creditCard.SecurityCode)
                {
                    yield return new ValidationResult("Security Code is invalid", new[] { nameof(SecurityCode) });
                }
                yield return ValidationResult.Success;
            }
        }
    }
}