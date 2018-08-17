using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDC.Web.Data;

public class SignedOutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public SignedOutModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    public IActionResult OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            _signInManager.SignOutAsync();
            // Redirect to home page if the user is authenticated.
            return RedirectToPage("/Index");
        }
        return Page();
    }
}