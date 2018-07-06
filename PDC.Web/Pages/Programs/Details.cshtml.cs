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
    public class DetailsModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DetailsModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

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
    }
}
