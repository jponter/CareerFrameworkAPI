using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CareerFrameworkAPI.Models;
using Microsoft.AspNetCore.Identity;
using CareerFrameworkAPI.Security;

namespace CareerFrameworkAPI.Models
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public SignIn SignInData { get; set; }

        private readonly SignInManager<AppIdentityUser> signinManager;


        public SignInModel(SignInManager<AppIdentityUser> signinManager
            )
        {
            this.signinManager = signinManager;
        }



        public void OnGet()
        {

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await signinManager.PasswordSignInAsync
                (SignInData.UserName, SignInData.Password,
                    SignInData.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToPage("/ListProf");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user details");
                }
            }
            return Page();
        }

    }
}