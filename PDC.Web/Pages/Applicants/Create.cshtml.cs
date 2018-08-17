using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Data;
using PDC.Web.Models;
using static PDC.Web.Models.tApplicant;

namespace PDC.Web.Pages.Applicants
{
    public class CreateModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["client"] = new SelectList(_context.tClient, "client_id", "client_name");
            ViewData["city"] = new SelectList(_context.tCity, "city_id", "city_name");
            return Page();
        }

        [BindProperty]
        public tApplicant tApplicant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            if (_context.tApplicant.Any(a => a.email == tApplicant.email)) {
                return RedirectToPage("");
            }
            else
            {
                var user = await _userManager.GetUserAsync(User);
                tApplicant.create_by = user.UserName;
                tApplicant.create_date = DateTime.Now;
                tApplicant.edit_by = user.UserName;
                tApplicant.status = "Approved";
                tApplicant.edit_date = DateTime.Now;
                tApplicant.last_login = DateTime.MaxValue;
                _context.tApplicant.Add(tApplicant);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            
        }
    }
}