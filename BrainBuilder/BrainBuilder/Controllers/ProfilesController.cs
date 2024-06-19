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

/*
 ********
 * Profiles Controller
 * Controller used for profiles
 * Date Created: 03/03/2021
 * Desert Sands 
 *********
*/

namespace BrainBuilder.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private readonly BrainBuilderDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public ProfilesController(BrainBuilderDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        /// <summary>
        /// Shows account
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(string name)
        {
            string defaultAvatar = "NAN";

            //Gets id of current user
            Accounts account = _context.Accounts.Where(p => p.Username == User.Identity.Name).FirstOrDefault();

            //Gets username from person class for profile page
            ViewData["Name"] = account.Username;

            //Gets information of the correct person
            var profile = await _context.Profiles
                .Include(p => p.ProvinceCodeNavigation)
                .FirstOrDefaultAsync(p => p.Id == account.AccountId);

            //If person is null
            if (profile == null)
            {
                return NotFound();
            }

            //Gets correct avatar
            var avatar = await _context.Avatars
                .FirstOrDefaultAsync(p => p.Id == account.AccountId);

            //Puts avatar code into a ViewData - if null, provide a default avatar
            if (avatar != null)
            {
                ViewData["Avatar"] = avatar.AvatarCode;
            }
            else
            {
                ViewData["Avatar"] = defaultAvatar;
            }

            //Determines if the user has a subscription
            if (profile.IsSubscribed == true)
            {
                ViewData["subscription"] = "MembershipPlus";

                //Checks if the subscription is active
                UserSubscriptions userSubscriptions = _context.UserSubscriptions.Where(u => u.AccountId == account.AccountId).FirstOrDefault();

                if (userSubscriptions.IsActive)
                {
                    ViewData["isActive"] = "T";
                }
                else
                {
                    ViewData["isActive"] = "F";
                }

            }
            else
            {
                ViewData["subscription"] = "Membership";
                ViewData["isActive"] = "F";
            }

            //Determines age for birthdate - if provided
            if (profile.BirthDate != null)
            {
                // Gets date for the age and today's date
                var today = DateTime.Today;
                var birthDate = (DateTime)profile.BirthDate;

                // Calculate the age.
                var age = today.Year - birthDate.Year;

                // Go back to the year in which the person was born in case of a leap year
                if (birthDate.Date > today.AddYears(-age))
                    age--;

                ViewData["age"] = age;
            }
            else
            {
                ViewData["age"] = String.Empty;
            }
            
            //Gets achievements information
            if (_context.Achievements.Any(e => e.Id == account.AccountId))
            {
                var achievementRecords = _context.Achievements.Where(p => p.Id == account.AccountId).FirstOrDefault();

                ViewData["achievements"] = true;
            }
            else
            {
                ViewData["achievements"] = false;
            }

            return View(profile);
        }

        // GET: Profile/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            string defaultAvatar = "NAN";

            //Gets correct avatar
            var avatar = await _context.Avatars
                .FirstOrDefaultAsync(p => p.Id == id);

            //Puts avatar code into a ViewData - if null, provide a default avatar
            if (avatar != null)
            {
                ViewData["Avatar"] = avatar.AvatarCode;
            }
            else
            {
                ViewData["Avatar"] = defaultAvatar;
            }

            if (id == null)
            {
                TempData["message"] = "Profile not found";
                return RedirectToAction("Index");
            }

            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                TempData["message"] = "Profile not found";
                return RedirectToAction("Index");
            }
            ViewData["Provinces"] = new SelectList(_context.Provinces, "Code", "ProvinceName", profile.ProvinceCode);
            ViewData["Genders"] = DSFillGenderList();
            return View(profile);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisplayName,Bio,Motto,ProvinceCode,Gender,BirthDate")] Profiles profile)
        {
            if (id != profile.Id)
            {
                TempData["message"] = "Profile Edit Failed";
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.Id))
                    {
                        TempData["message"] = "Profile Edit Failed";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { User.Identity.Name });
            }
            ViewData["Provinces"] = new SelectList(_context.Provinces, "Code", "ProvinceName", profile.ProvinceCode);
            ViewData["Genders"] = DSFillGenderList();
            ViewData["Genders"] = DSFillGenderList(profile.Gender);
            return View(profile);
        }

        /// <summary>
        /// Determines if a certain profile exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }

        /// <summary>
        /// Fills a selectlist with possible gender selections
        /// </summary>
        /// <returns></returns>
        public SelectList DSFillGenderList(string input = "")
        {
            List<string> genders = new List<string>();

            genders.Add("");
            genders.Add("Male");
            genders.Add("Female");
            genders.Add("Other");

            return new SelectList(genders, input);
        }

    }
}
