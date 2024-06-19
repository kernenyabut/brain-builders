using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainBuilder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

/*
 ********
 * Games Controller
 * Controller used for games
 * Date Created: 04/092021
 * Desert Sands 
 *********
*/


namespace BrainBuilder.Controllers
{
    public class GamesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly BrainBuilderDBContext _context;


        public GamesController(RoleManager<IdentityRole> roleManager,
                                UserManager<IdentityUser> userManager,
                                BrainBuilderDBContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public partial class InputModel
        {
            public int FinalScore { get; set; }

            public int MovesTaken { get; set; }

            public int TimeTaken { get; set; }

        }

        public async Task<IActionResult> Index()
        {
            //Lists through game information 
            var games = _context.Games.OrderBy(g => g.GameId);
            return View(await games.ToListAsync());
            //return View();
        }

        // GET: Games/Details/5
        public IActionResult Details(int gameId)
        {
            //For now, the game will redirect to matching
            return RedirectToAction("MatchingGame");
        }

        public IActionResult MatchingGame()
        {
            InputModel inputModel = new InputModel();

            return View(inputModel);
        }

        public IActionResult MathGame()
        {
            InputModel inputModel = new InputModel();

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Submit_Matching(InputModel input)
        {
            //Checks if user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                //Gets id of current user
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                //Gets information of the correct person
                var profile = await _context.Profiles
                    .Include(p => p.ProvinceCodeNavigation)
                    .FirstOrDefaultAsync(p => p.Id == account.AccountId);

                //Adds stat to database
                var gameStats = new GameStats
                {
                    //Id = account.AccountId,
                    AccountId = account.AccountId,
                    GameId = 1,
                };

                _context.Add(gameStats);
                await _context.SaveChangesAsync();

                //Adds matching stats to database
                var matchingGameStats = new GameStatsMatching
                {
                    Id = gameStats.Id,
                    AccountId = account.AccountId,
                    FinalScore = input.FinalScore,
                    MovesTaken = input.MovesTaken,
                    TimeTaken = input.TimeTaken,
                    Date = DateTime.Now
                };

                _context.Add(matchingGameStats);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Game stat added successfully.";
                //StatusMessage = "An error has occured, please try again.";
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Games");

                /*
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
                    return RedirectToAction("Index", "Games");
                }
                */
            }
            else
            {
                return RedirectToAction("Index", "Games");
            }
        }
    }
}
