using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Cities
{
    public class DeleteModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DeleteModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tCity tCity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tCity = await _context.tCity
                .Include(t => t.province).SingleOrDefaultAsync(m => m.city_id == id);

            if (tCity == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tCity = await _context.tCity.FindAsync(id);

            if (tCity != null)
            {
                _context.tCity.Remove(tCity);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
