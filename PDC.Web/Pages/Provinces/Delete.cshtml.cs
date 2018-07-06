using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Provinces
{
    public class DeleteModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DeleteModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tProvince tProvince { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tProvince = await _context.tProvince.SingleOrDefaultAsync(m => m.province_id == id);

            if (tProvince == null)
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

            tProvince = await _context.tProvince.FindAsync(id);

            if (tProvince != null)
            {
                _context.tProvince.Remove(tProvince);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
