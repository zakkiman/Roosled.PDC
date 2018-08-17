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

namespace PDC.Web.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IdentityRole role { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //var r = new IdentityRole { Name = role.Name, NormalizedName=role.Name.ToUpper() };
            IdentityRole ir = _context.Roles.Where(r => r.Name == role.Name).SingleOrDefault();
            role.NormalizedName = role.Name.ToUpper();
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}