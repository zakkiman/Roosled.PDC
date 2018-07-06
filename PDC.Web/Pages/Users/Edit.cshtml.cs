using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public EditModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tUser tUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tUser = await _context.tUser.SingleOrDefaultAsync(m => m.user_id == id);

            if (tUser == null)
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

            _context.Attach(tUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tUserExists(tUser.user_id))
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
            return _context.tUser.Any(e => e.user_id == id);
        }
    }
}
