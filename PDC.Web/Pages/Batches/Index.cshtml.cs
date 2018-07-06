using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Batches
{
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public IndexModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public string nameSort { get; set; }
        public string genderSort { get; set; }
        public string currentSort { get; set; }

        public IList<ClientApplicantProgram> Batches { get; set; }
        //public IList<tApplicantProgram> Batches { get; set; }
        public IList<Batch> batch { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            nameSort = string.IsNullOrEmpty(sortOrder) ? "first_desc" : "";
            genderSort = sortOrder == "Gender" ? "gender_desc" : "Gender";
            
            ////var batches = _context.tApplicantProgram.Join(_context.tClient, ap => ap.applicant.client.client_id, c => c.client_id, (ap, c) => new { ap, c }).ToListAsync();
            IQueryable<ClientApplicantProgram> batches = (from ap in _context.tApplicantProgram
                           join a in _context.tApplicant on ap.applicant.applicant_id equals a.applicant_id
                           join p in _context.tProgram on ap.program.program_id equals p.program_id
                           join c in _context.tClient on a.client.client_id equals c.client_id
                           select new ClientApplicantProgram()
                           {
                               id = ap.applicant_program_id,
                               client_id = c.client_id,
                               client_name = c.client_name,
                               applicant_id = a.applicant_id,
                               first_name = a.first_name,
                               last_name = a.last_name,
                               program_id = p.program_id,
                               program_name = p.program_name,
                               batch_name = ap.batch_name,
                               status = ap.approval_status,
                               approved_by = ap.approved_by,
                               approved_date = ap.approved_date,
                               gender = a.gender,
                               dob = a.dob
                           });
            switch (sortOrder)
            {
                case "first_desc":
                    batches = batches.OrderByDescending(b => b.first_name);break;
                case "gender_desc":
                    batches = batches.OrderByDescending(b => b.gender);break;
                case "Gender":
                    batches = batches.OrderBy(b => b.gender);break;
                default:
                    batches = batches.OrderBy(b => b.last_name);break;
            }
            Batches = await batches.ToListAsync();
            IList<tApplicantProgram> temp;
            temp = await _context.tApplicantProgram.AsNoTracking().ToListAsync();

            foreach (tApplicantProgram ap in temp)
            {
                tApplicant apl = _context.tApplicant.SingleOrDefault(a => a.applicant_id == ap.applicant_id);
                tClient clt = _context.tClient.SingleOrDefault(c => c.client_id == apl.client_id);
                apl.client = new tClient();
                apl.client = clt;
                ap.applicant = new tApplicant();
                ap.applicant = apl;
            }
            var smt = (from baru in _context.tApplicantProgram
                       select new Batch()
                       { client_name = baru.applicant.client.client_name, batch_name = baru.batch_name, program_id = baru.program_id, approval_status = baru.approval_status, approved_by = baru.approved_by, approved_date = baru.approved_date, batch_start = baru.batch_start, batch_end = baru.batch_end }).Distinct();
            batch = await smt.AsNoTracking().ToListAsync();
        }
    }
}