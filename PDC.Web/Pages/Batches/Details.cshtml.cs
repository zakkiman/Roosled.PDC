using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Batches
{
    public class DetailsModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DetailsModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public tBatch tBatch { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tBatch = await _context.tBatch
                .Include(t => t.client).SingleOrDefaultAsync(m => m.batch_id == id);

            if (tBatch == null)
            {
                return NotFound();
            }
            else
            {
                tBatch.applicantPrograms = await _context.tApplicantProgram.Where(ap => ap.batch_id == tBatch.batch_id).ToListAsync();
                tBatch.client = await _context.tClient.Where(c => c.client_id == tBatch.client_id).SingleOrDefaultAsync();
                for(int i = 0; i < tBatch.applicantPrograms.Count; i++)
                {
                    tBatch.applicantPrograms[i].applicant = await _context.tApplicant.Where(a => a.applicant_id == tBatch.applicantPrograms[i].applicant_id).SingleOrDefaultAsync();
                    tBatch.applicantPrograms[i].program = await _context.tProgram.Where(p => p.program_id == tBatch.applicantPrograms[i].program_id).SingleOrDefaultAsync();
                }
            }
            return Page();
        }
    }
}
