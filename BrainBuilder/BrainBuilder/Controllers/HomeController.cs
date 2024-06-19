using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BrainBuilder.Models;
using Microsoft.AspNetCore.Identity;

/*
 ********
 * Home Controller
 * Controller used for the home page
 * Date Created: 02/25/2021
 * Desert Sands 
 *********
*/


namespace BrainBuilder.Controllers
{
    public class HomeController : Controller
    {
        private readonly BrainBuilderDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(BrainBuilderDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            //If user has already signed in - change the landing screen to refer to the games
            if (User.Identity.IsAuthenticated)
            {
                Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

                ViewData["userName"] = account.Username;
                ViewData["isLoggedIn"] = true;
            }
            else
            {
                ViewData["isLoggedIn"] = false;
            }
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Put admin user into admin role
        /// </summary>
        /// <param name="userManager"></param>
        /// <returns></returns>
        private async Task<IActionResult> DSInitAdmin(UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByNameAsync("admin@admin.com");
            var inAdmin = await userManager.IsInRoleAsync(user, "Admin");
            if (!inAdmin)
            {
                await userManager.AddToRoleAsync(user, "Employee");
                await userManager.AddToRoleAsync(user, "Admin");
            }
            return null;
        }
    }
}
