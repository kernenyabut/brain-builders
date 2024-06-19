using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BrainBuilder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using DesertSandsClassLibrary;

namespace BrainBuilder.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly BrainBuilderDBContext _dbcontext;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            BrainBuilderDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _dbcontext = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public partial class InputModel
        {
            [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "User Name")]
            public string UserName { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Province")]
            public string ProvinceCode { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ViewData["Provinces"] = new SelectList(_dbcontext.Provinces, "Code", "ProvinceName");
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.UserName, Email = Input.Email };
                var account = new Accounts
                {
                    Username = Input.UserName,
                    Email = Input.Email,
                    ProvinceCode = Input.ProvinceCode,
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    //Adds new profile
                    ViewData["message"] = account.Username + "'s account succesfully added.";
                    _dbcontext.Add(account);
                    await _dbcontext.SaveChangesAsync();

                    //Adds new profile
                    var profile = new Profiles { Id = account.AccountId, DisplayName = account.Username, ProvinceCode = account.ProvinceCode, Bio = "", Motto = "", PromotionalEmails = true, IsSubscribed = false};
                    _dbcontext.Add(profile);
                    await _dbcontext.SaveChangesAsync();

                    //Adds default profile picture based on the username
                    string avatarCode = account.Username;
                    var avatar = new Avatars { Id = account.AccountId, AvatarCode = avatarCode};
                    _dbcontext.Add(avatar);
                    await _dbcontext.SaveChangesAsync();

                    //Adds achievement record - for testing only
                    /*
                    var achievementRecord = new Achievements { Id = account.AccountId, GameId = null, DatePlayed = null};
                    _dbcontext.Add(achievementRecord);
                    await _dbcontext.SaveChangesAsync();
                    */
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_signInManager.IsSignedIn(User) && User.IsInRole("Employee"))
                    {
                        await _userManager.AddToRoleAsync(user, "Employee");
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        //adds user to the Members role upon regristration
                        await _userManager.AddToRoleAsync(user, "Member");
                    }

                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            ViewData["Provinces"] = new SelectList(_dbcontext.Provinces, "Code", "ProvinceName", Input.ProvinceCode);

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public partial class InputModel : IValidatableObject
        {
            BrainBuilderDBContext brainBuilderDBContext = new BrainBuilderDBContext();

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (UserName == null || UserName.Trim() == "")
                {
                    yield return new ValidationResult("Username cannot be empty", new[] { nameof(UserName) });
                }
                else
                {
                    UserName = UserName.Trim();
                    Accounts account = brainBuilderDBContext.Accounts.Where(p => p.Username == UserName).FirstOrDefault();
                    if (account != null)
                    {
                        yield return new ValidationResult("User Name already in use", new[] { nameof(UserName) });
                    }
                }

                if (Email == null || Email.Trim() == "")
                {
                    yield return new ValidationResult("Email cannot be empty", new[] { nameof(Email) });
                }
                else
                {
                    Email = Email.Trim();
                    if (!DesertSandsValidation.DSEmailValidation(Email))
                    {
                        yield return new ValidationResult("Email is not in the right format. EX. test@test.ca", new[] { nameof(Email) });
                    }
                    else
                    {
                        Accounts account = brainBuilderDBContext.Accounts.Where(p => p.Email == Email).FirstOrDefault();
                        if (account != null)
                        {
                            yield return new ValidationResult("Email already in use", new[] { nameof(Email) });
                        }
                    }
                }

                if (ProvinceCode == null || ProvinceCode.Trim() == "")
                {
                    yield return new ValidationResult("Canada must have corresponding province", new[] { nameof(ProvinceCode) });
                }
       
                if (Password != null && Password.Trim() != "")
                {
                    if (!DesertSandsValidation.DSStrongPassword(Password))
                    {
                        yield return new ValidationResult("Password must have at least one capital letter, one number, and one symbol(!@#$&*).", new[] { nameof(Password) });

                    }
                }
                    yield return ValidationResult.Success;
                }
            }
        }
}
