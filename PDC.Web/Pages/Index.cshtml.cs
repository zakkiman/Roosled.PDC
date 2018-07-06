using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        public IndexModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }
        public IList<tProgram> tPrograms { get; set; }
        public IList<tProvince> tProvinces { get; set; }
        public IList<tApplicant> applicants { get; set; }
        public IList<Batch> batches { get; set; }
        public int sumApprovedApplicants { get; set; }
        //public int percentApplicants { get; set; }
        public async Task OnGetAsync()
        {
            tPrograms = await _context.tProgram.ToListAsync();
            tProvinces = await _context.tProvince.ToListAsync();
            applicants = await _context.tApplicant.ToListAsync();
            var smt = (from baru in _context.tApplicantProgram
                       select new Batch()
                       { client_name = baru.applicant.client.client_name, batch_name = baru.batch_name, program_id = baru.program_id, approval_status = baru.approval_status, approved_by = baru.approved_by, approved_date = baru.approved_date, batch_start = baru.batch_start, batch_end = baru.batch_end }).Distinct();
            batches = await smt.AsNoTracking().ToListAsync();
            sumApprovedApplicants = _context.tApplicant
                .Where(a => a.status == "Approved").Count();
            
            //percentApplicants = (sumApprovedApplicants / applicants.Count());
        }
    }
}
