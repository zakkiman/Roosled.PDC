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
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public IndexModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public IList<tApplicant> tApplicant { get;set; }

        public async Task OnGetAsync()
        {
            tApplicant = await _context.tApplicant.ToListAsync();
        }
        public async Task<IActionResult> OnPostRejectAsync(int ID)
        {

            tApplicant applicant = await _context.tApplicant.SingleOrDefaultAsync(a => a.applicant_id == ID);
            _context.Attach(applicant).State = EntityState.Modified;
            applicant.status = "Rejected";
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostApproveAsync(int ID)
        {

            tApplicant applicant = await _context.tApplicant.SingleOrDefaultAsync(a => a.applicant_id == ID);
            _context.Attach(applicant).State = EntityState.Modified;
            applicant.status = "Approved";
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
