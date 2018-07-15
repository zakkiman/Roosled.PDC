using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Reports.Detail
{
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public IndexModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public tApplicant applicant { get; set; }
        public tProgram program { get; set; }
        public List<tApplicant> applicants { get; set; }
        public IList<tApplicantProgram> applicantPrograms { get; set; }
        
        public async Task OnGetAsync(int? clientID, int? batchID)
        {
            ViewData["client"] = new SelectList(_context.tClient, "client_id", "client_name");
            ViewData["batch"] = new SelectList(_context.tBatch, "batch_id", "batch_name");
            applicants = new List<tApplicant>();
            if (clientID != null || batchID != null)
            {
                applicantPrograms = await _context.tApplicantProgram.Where(ap => ap.batch_id == batchID).ToListAsync();
                for (int i = 0; i < applicantPrograms.Count; i++)
                {
                    applicant = await _context.tApplicant.SingleOrDefaultAsync(a => a.applicant_id == applicantPrograms[i].applicant_id && a.client_id == clientID);
                    program = await _context.tProgram.SingleOrDefaultAsync(p => p.program_id == applicantPrograms[i].program_id);

                    applicantPrograms[i].applicant = new tApplicant();
                    applicantPrograms[i].applicant = applicant;
                    applicantPrograms[i].program = new tProgram();
                    applicantPrograms[i].program = program;
                }
            }
        }
        public async Task<IActionResult> OnPostSearchAsync()
        {

            //tApplicant applicant = await _context.tApplicant.SingleOrDefaultAsync(a => a.full_name == Name);
            //_context.Attach(applicant).State = EntityState.Modified;
            //applicant.status = "Approved";
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
            
            return RedirectToPage("./Index");
        }
    }
}
