using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly PDC.Web.Models.PDCContext _context;

        public DeleteModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, PDC.Web.Models.PDCContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public ApplicationUser tUser { get; set; }
        [BindProperty]
        public IdentityRole Roles { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            ViewData["roles"] = new SelectList(_context.Roles, "Name", "Name");
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var userRoles = await _context.UserRoles.SingleOrDefaultAsync(u => u.UserId == id);

            tUser = await _userManager.FindByIdAsync(id);
            if (tUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            //_context.Attach(tUser).State = EntityState.Modified;
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                IList<string> roles = await _userManager.GetRolesAsync(user);
                foreach (string r in roles)
                {
                    await _userManager.RemoveFromRoleAsync(user, r);
                }
                await _userManager.DeleteAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tUserExists(tUser.UserName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        private bool tUserExists(string id)
        {
            return _context.Users.Any(e => e.UserName == id);
        }
    }
}
