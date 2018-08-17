using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages.Clients
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
            return Page();
        }

        [BindProperty]
        public tClient tClient { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);
            tClient.create_by = user.UserName;
            tClient.create_date = DateTime.Now;
            tClient.edit_by = user.UserName;
            tClient.edit_date = DateTime.Now;
            _context.tClient.Add(tClient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}