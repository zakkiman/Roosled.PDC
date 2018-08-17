using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public IdentityRole role { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            role = await _context.Roles.SingleOrDefaultAsync(m => m.Id == id);

            if (role == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
