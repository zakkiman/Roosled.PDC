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
        public IList<tApplicant> applicants { get; set; }
        public IList<tAnswer> answers { get; set; }
        public IList<tAppllicantAnswer> tAppllicantAnswer { get;set; }

        public async Task OnGetAsync(int? ID, string firstName, string lastName)
        {
            ViewData["client"] = new SelectList(_context.tClient, "client_id", "client_name");
            
            applicants = await _context.tApplicant.ToListAsync();
            if(ID!=null || firstName!=null || lastName != null)
            {
                applicants = applicants.Where(a => a.client_id == ID || (a.first_name.Contains(firstName) || a.last_name.Contains(lastName))).ToList();
                if (applicants.Count > 0)
                {
                    foreach (tApplicant a in applicants)
                    {
                        tAppllicantAnswer = await _context.tApplicantAnswer.Where(ata => ata.applicant_id == a.applicant_id).ToListAsync();
                    }
                }
            }
        }
        public async Task<IActionResult> OnPostSearchAsync(string Name)
        {

            tApplicant applicant = await _context.tApplicant.SingleOrDefaultAsync(a => a.full_name == Name);
            _context.Attach(applicant).State = EntityState.Modified;
            applicant.status = "Approved";
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
