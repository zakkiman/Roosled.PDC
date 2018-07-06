using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Applicants
{
    public class DetailsModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DetailsModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public tApplicant tApplicant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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
    }
}
