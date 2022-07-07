using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

using Cshop.Models;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;


namespace Cshop.Controllers
{
    public class AuthController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }




        public IActionResult Index()
        {
            return View();
        }



        [AllowAnonymous]
        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            LoginViewModel input = new LoginViewModel();
            return View(input);
        }



        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([Bind("Username,Password,RememberMe")] LoginViewModel logininput, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/admin");


            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(logininput.Username, logininput.Password, logininput.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {


                    var user = await _userManager.FindByNameAsync(logininput.Username);

                    var roles = await GetUserRoles(user);


                    
                    if (!roles.Contains("Administrator") && !roles.Contains("ShopOwner"))
                    {
                        return LocalRedirect("/");
                    }
                    else
                    {
                        return LocalRedirect(returnUrl);
                    }

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(logininput);
                }
            }

            return View(logininput);
        }


    


        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }

        


        [HttpPost("/register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerinput)
        {
            if (!ModelState.IsValid)
            {
                return View(registerinput);
            }

            User user = new User
            {
                UserName = registerinput.Username
            };


            var result = await _userManager.CreateAsync(user, registerinput.Password);


            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(registerinput);
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    





            // Add a Action in Controller for Log Out.
            [AllowAnonymous]
            [Route("/logout")]
            public async Task<IActionResult> Logout(string returnUrl = null)
            {
                await _signInManager.SignOutAsync();

                if (returnUrl != null)
                {
                 return LocalRedirect(returnUrl);

                }
                else
                {
                    //return LocalRedirect("/Admin");
                    return LocalRedirect("/");
                }
            }



        
        [AllowAnonymous]
        [Route("/myprofile")]
        public async Task<IActionResult> Myprofile(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
            {
                //return LocalRedirect(returnUrl);
                return LocalRedirect("/");

            }
            else
            {
                //return LocalRedirect("/Admin");
                return LocalRedirect("/myprofile");
            }
        }





        private Task<User> GetCurrentUserAsync()
            {
                return _userManager.GetUserAsync(HttpContext.User);
            }

            private async Task<List<string>> GetUserRoles(User user)
            {
                return new List<string>(await _userManager.GetRolesAsync(user));
            }







        //public class InputModel
        public class LoginViewModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            public string Username { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>


            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>


            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }




        }


        public class RegisterViewModel
        {
            [Required]
            public string Username { get; set; }



            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; }



            [Display(Name = "Please input your password agagin!")]
            public bool PleaseInputYourPasswordAgain { get; set; }





            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

        }



    }
}
