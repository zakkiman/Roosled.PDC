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

            tBatch batch = await _context.tBatch.SingleOrDefaultAsync(a => a.batch_id == ID);
            _context.Attach(batch).State = EntityState.Modified;
            batch.approval_status = "Rejected";
            batch.approved_by = "System";
            batch.approved_date = DateTime.Now.ToString();
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostApproveAsync(int ID)
        {

            tBatch batch = await _context.tBatch.SingleOrDefaultAsync(a => a.batch_id == ID);
            _context.Attach(batch).State = EntityState.Modified;
            batch.approval_status = "Approved";
            batch.approved_by = "System";
            batch.approved_date = DateTime.Now.ToString();
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
