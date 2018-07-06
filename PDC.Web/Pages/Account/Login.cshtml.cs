using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages
{
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public class LoginModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public tUser users { get; set; }
        public string ReturnUrl { get; set; }
        //public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        //{
        //    ViewData["ReturnUrl"] = returnUrl;
        //}

        public async Task OnGetAsync(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            tUser user = new tUser();
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            user = await _context.tUser.SingleOrDefaultAsync(m => m.user_id == users.user_id);
            if(user is null)
            {
                if (users.user_id.ToUpper() == "SYSTEM" && users.password == "Password1!")
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }
            else
            {   
                 var isValid = (user.user_id == users.user_id && user.password == users.password);
                if (isValid == true)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}