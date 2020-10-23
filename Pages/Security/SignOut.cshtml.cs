using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CareerFrameworkAPI.Models;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Authorization;
using CareerFrameworkAPI.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CareerFrameworkAPI.Pages
{ 
    [Authorize]
    public class SignOutModel : PageModel
    {
        //private readonly SignInManager<AppIdentityUser> signinManager;
        private IOptions<OidcOptions> options;

        public SignOutModel( IOptions<OidcOptions> options)
        {
           
            this.options = options;
        }

        public async Task<IActionResult> OnPost()
        {
            //await LogoutUser(User.FindFirstValue("onelogin-access-token"));
            await HttpContext.SignOutAsync();
            //return RedirectToPage("/");
            // raise the logout event


            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            SignOut();

            return Redirect("/");



        }

        
        
    }
}