using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages.Batches
{
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string nameSort { get; set; }
        public string genderSort { get; set; }
        public string currentSort { get; set; }

        public IList<tBatch> batches { get; set; }
        public static tBatch batchTemp { get; set; }
        public async Task OnGetAsync()
        {
            batches = await _context.tBatch.Include(c => c.client).Where(b => b.isExpired == false).ToListAsync();

            for(int i = 0; i < batches.Count; i++)
            {
                batches[i].applicantPrograms = await _context.tApplicantProgram.Include(a => a.applicant).Include(p => p.program).Where(ap => ap.batch_id == batches[i].batch_id).ToListAsync();
                //// get applicants list
                //for (int j = 0; j < batches[i].applicantPrograms.Count; j++)
                //{
                //    batches[i].applicantPrograms[j].applicant = await _context.tApplicant.SingleOrDefaultAsync(a => a.applicant_id == batches[i].applicantPrograms[j].applicant_id);
                //    batches[i].applicantPrograms[j].program = await _context.tProgram.SingleOrDefaultAsync(p => p.program_id == batches[i].applicantPrograms[j].program_id);
                //}
                //// get client data
                //batches[i].client = await _context.tClient.SingleOrDefaultAsync(c => c.client_id == batches[i].client_id);

            }

            //switch (sortOrder)
            //{
            //    case "first_desc":
            //        batches = batches.OrderByDescending(b => b.applicantPrograms);break;
            //    case "gender_desc":
            //        batches = batches.OrderByDescending(b => b.gender);break;
            //    case "Gender":
            //        batches = batches.OrderBy(b => b.gender);break;
            //    default:
            //        batches = batches.OrderBy(b => b.last_name);break;
            //}
            //Batches = await batches.ToListAsync();
            //IList<tApplicantProgram> temp;
            //temp = await _context.tApplicantProgram.AsNoTracking().ToListAsync();

            //foreach (tApplicantProgram ap in temp)
            //{
            //    tApplicant apl = _context.tApplicant.SingleOrDefault(a => a.applicant_id == ap.applicant_id);
            //    tClient clt = _context.tClient.SingleOrDefault(c => c.client_id == apl.client_id);
            //    apl.client = new tClient();
            //    apl.client = clt;
            //    ap.applicant = new tApplicant();
            //    ap.applicant = apl;
            //}
            //var smt = (from baru in _context.tApplicantProgram
            //           select new Batch()
            //           { client_name = baru.applicant.client.client_name, batch_name = baru.batch_name, program_id = baru.program_id, approval_status = baru.approval_status, approved_by = baru.approved_by, approved_date = baru.approved_date, batch_start = baru.batch_start, batch_end = baru.batch_end }).Distinct();
            //batch = await smt.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostRejectAsync(int ID)
        {
            var user = await _userManager.GetUserAsync(User);
            tBatch batch = await _context.tBatch.SingleOrDefaultAsync(b => b.batch_id == ID);
            batchTemp = batch;
            _context.Attach(batch).State = EntityState.Modified;
            batch.approval_status = "Rejected";
            batch.isExpired = true;
            batch.approved_date = DateTime.Now.ToString("dd MMM yyyy HH:mm");
            batch.approved_by = user.UserName;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnPostApproveAsync(int ID)
        {
            var user = await _userManager.GetUserAsync(User);
            tBatch batch = await _context.tBatch.SingleOrDefaultAsync(b => b.batch_id == ID);
            _context.Attach(batch).State = EntityState.Modified;
            batch.approval_status = "Approved";
            batch.approved_date = DateTime.Now.ToString("dd MMM yyyy HH:mm");
            batch.approved_by = user.UserName;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}