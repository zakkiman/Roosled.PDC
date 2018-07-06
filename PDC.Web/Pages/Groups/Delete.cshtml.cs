using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Groups
{
    public class DeleteModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DeleteModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tGroup tGroup { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tGroup = await _context.tGroup.SingleOrDefaultAsync(m => m.group_id == id);

            if (tGroup == null)
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

            tGroup = await _context.tGroup.FindAsync(id);

            if (tGroup != null)
            {
                _context.tGroup.Remove(tGroup);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
