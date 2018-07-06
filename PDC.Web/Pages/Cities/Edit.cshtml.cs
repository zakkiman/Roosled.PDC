using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Cities
{
    public class EditModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public EditModel(PDC.Web.Models.PDCContext context)
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
           ViewData["province_id"] = new SelectList(_context.tProvince, "province_id", "province_id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tCityExists(tCity.city_id))
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

        private bool tCityExists(int id)
        {
            return _context.tCity.Any(e => e.city_id == id);
        }
    }
}
