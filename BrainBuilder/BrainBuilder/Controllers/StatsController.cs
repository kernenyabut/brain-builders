using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainBuilder.Data;
using BrainBuilder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BrainBuilder.Controllers
{

    /*
     ********
     * Stats Controller
     * Controller used for the stats
     * Date Created: 04/07/2021
     * Desert Sands 
     *********
    */

    [Authorize]
    public class StatsController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly BrainBuilderDBContext _context;


        public StatsController(RoleManager<IdentityRole> roleManager,
                                UserManager<IdentityUser> userManager,
                                BrainBuilderDBContext context)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            _context = context;

        }

        public async Task<IActionResult> Index()
        {
            //Gets id of current user
            Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

            //Gets username from person class for profile page
            ViewData["Name"] = account.Username;

            //Checks if the user has any stats
            var stats = await _context.GameStats
                .FirstOrDefaultAsync(p => p.AccountId == account.AccountId);
            
            //Determines if there are any stats from the user
            if (stats != null)
            {
                //Gets stats overall
                var overallStats = _context.GameStats;

                //Gets user's stats
                var userGameStats = _context.GameStats
                    .Include(g => g.Game)
                    .Where(g => g.AccountId.Equals(account.AccountId));

                //Puts stats into a list to be populated
                List<GameStats> userGameStatsList = userGameStats.ToList();
                List<GameStats> overallStatsList = overallStats.ToList();

                //List<List<GameStats>> gameStatsList = new List<List<GameStats>>();

                //Gets stats for matchingGame - if it exists
                List<GameStats> matchingGameStats = userGameStatsList
                    .Where(g => g.GameId == 1).ToList();

                if (matchingGameStats.Any())
                {
                    //Gets overall stats for comparing
                    List<GameStatsMatching> overallMatchingStatsList = _context.GameStatsMatching.ToList();

                    //Gets matching Stats
                    List<GameStatsMatching> matchingStatsList = _context.GameStatsMatching
                        .Where(p => p.AccountId == account.AccountId).ToList();

                    //Lists - user
                    List<int> scores = new List<int>();
                    List<string> dates = new List<string>();
                    List<int> movesTaken = new List<int>();
                    List<int> timeTaken = new List<int>();

                    //Gets list of scores overall
                    List<int> overallScores = new List<int>();
                    List<int> overallMoves = new List<int>();
                    List<int> overallTime = new List<int>();

                    //Populates score, timeTaken, and movesTaken from matchingStatsList
                    foreach (GameStatsMatching stat in matchingStatsList)
                    {
                        scores.Add((int)stat.FinalScore);
                        movesTaken.Add((int)stat.MovesTaken);
                        timeTaken.Add((int)stat.TimeTaken);
                        dates.Add(stat.Date.ToString());
                    }

                    //Populates score, timeTaken, and movesTaken from overallMatchingStatsList
                    foreach (GameStatsMatching stat in overallMatchingStatsList)
                    {
                        overallScores.Add((int)stat.FinalScore);
                        overallMoves.Add((int)stat.MovesTaken);
                        overallTime.Add((int)stat.TimeTaken);
                    }

                    //Sorts by reverse for the latest scores
                    scores.Reverse();
                    movesTaken.Reverse();
                    timeTaken.Reverse();
                    dates.Reverse();

                    ViewData["matchingScores"] = scores.ToArray();
                    ViewData["matchingMoves"] = movesTaken.ToArray();
                    ViewData["matchingTime"] = timeTaken.ToArray();

                    ViewData["matchingDates"] = dates.ToArray();

                    ViewData["matchingOverallScores"] = overallScores.ToArray();
                    ViewData["matchingOverallMoves"] = overallMoves.ToArray();
                    ViewData["matchingOverallTime"] = overallTime.ToArray();

                    ViewData["statsExist"] = true;
                    ViewData["matchingStatsExist"] = true;
                }
                else
                {
                    ViewData["matchingStatsExist"] = false;
                }

                //Checks for games number of games played

                //Populates lists based on the different games the user has played
                var differentGamesPlayed = userGameStats.GroupBy(g => g.GameId).Select(y => y.First()).Distinct();
                List<GameStats> differentGamesPlayedList = differentGamesPlayed.ToList();

                //Gets list of gameName and timesPlayed
                List<int> timesPlayedList = new List<int>();
                List<string> gameNameList = new List<string>();

                //Populates score and dates with finalscore and date from gamesPlayedList
                foreach (GameStats game in differentGamesPlayed)
                {
                    int count = userGameStats.Where(g => g.GameId == game.GameId).Count();

                    timesPlayedList.Add(count);
                    gameNameList.Add(game.Game.Name);
                }

                ViewData["gameNames"] = gameNameList.ToArray();
                ViewData["timesPlayed"] = timesPlayedList.ToArray();


            }
            else
            {
                ViewData["statsExist"] = false;
                ViewData["matchingStatsExist"] = false;
            }

            //Determines if user has a membership
            var profile = _context.Profiles
                .FirstOrDefault(p => p.Id == account.AccountId);

            //Determines if the user has a subscription
            if (profile.IsSubscribed == true)
            {
                //Checks if the subscription is active
                UserSubscriptions userSubscriptions = _context.UserSubscriptions.Where(u => u.AccountId == account.AccountId).FirstOrDefault();

                if (userSubscriptions.IsActive)
                {
                    ViewData["isActive"] = true;
                }
                else
                {
                    ViewData["isActive"] = false;
                }

            }
            else
            {
                ViewData["isActive"] = false;
            }



            return View();
        }

        /// <summary>
        /// Determines if a certain stat record exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool GameStatsExists(int id)
        {
            return _context.GameStats.Any(e => e.AccountId == id);
        }
    }
}