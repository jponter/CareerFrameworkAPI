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

namespace CareerFrameworkAPI.Pages
{ 
    [Authorize]
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<AppIdentityUser> signinManager;

        public SignOutModel(SignInManager<AppIdentityUser> signinManager)
        {
            this.signinManager = signinManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await signinManager.SignOutAsync();
            return RedirectToPage("/Security/SignIn");
        }
    }
}