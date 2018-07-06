using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Programs
{
    public class DeleteModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DeleteModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tProgram tProgram { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tProgram = await _context.tProgram.SingleOrDefaultAsync(m => m.program_id == id);

            if (tProgram == null)
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

            tProgram = await _context.tProgram.FindAsync(id);

            if (tProgram != null)
            {
                //_context.tProgram.Remove(tProgram);
                tProgram.approval_status = "Rejected";
                tProgram.approved_by = "System";
                _context.tProgram.Update(tProgram);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
