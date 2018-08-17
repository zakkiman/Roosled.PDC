using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages.Applicants
{
    public class EditModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public EditModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public tApplicant tApplicant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["client"] = new SelectList(_context.tClient, "client_id", "client_name");
            ViewData["city"] = new SelectList(_context.tCity, "city_id", "city_name");
            if (id == null)
            {
                return NotFound();
            }

            tApplicant = await _context.tApplicant.SingleOrDefaultAsync(m => m.applicant_id == id);

            if (tApplicant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tApplicant).State = EntityState.Modified;

            try
            {
                var user = await _userManager.GetUserAsync(User);
                tApplicant.edit_by = user.UserName;
                tApplicant.edit_date = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tApplicantExists(tApplicant.applicant_id))
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

        private bool tApplicantExists(int id)
        {
            return _context.tApplicant.Any(e => e.applicant_id == id);
        }
    }
}
