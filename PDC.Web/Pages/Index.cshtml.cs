using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PDC.Web.Data;
using PDC.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace PDC.Web.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly PDC.Web.Models.PDCContext _context;
        public IndexModel(PDC.Web.Models.PDCContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IList<tProgram> tPrograms { get; set; }
        public IList<tProvince> tProvinces { get; set; }
        public IList<tApplicant> applicants { get; set; }
        public IList<tBatch> batches { get; set; }
        public int sumApprovedApplicants { get; set; }
        
        public async Task OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            //}

            sumApprovedApplicants = 0;
            
            tPrograms = await _context.tProgram.ToListAsync();
            tProvinces = await _context.tProvince.ToListAsync();
            applicants = await _context.tApplicant.ToListAsync();
            //var smt = (from baru in _context.tApplicantProgram
            //           select new Batch()
            //           { client_name = baru.applicant.client.client_name, batch_name = baru.batch_name, program_id = baru.program_id, approval_status = baru.approval_status, approved_by = baru.approved_by, approved_date = baru.approved_date, batch_start = baru.batch_start, batch_end = baru.batch_end }).Distinct();
            //batches = await smt.AsNoTracking().ToListAsync();
            sumApprovedApplicants = _context.tApplicant.Count();

            batches = await _context.tBatch.Where(b => b.isExpired ==false).ToListAsync();
            for(int i = 0; i < batches.Count; i++)
            {
                if (batches[i].batch_end < DateTime.Now)
                {
                    _context.Attach(batches[i]).State = EntityState.Modified;
                    batches[i].isExpired = true;
                    await _context.SaveChangesAsync();
                    batches.RemoveAt(i);
                }
            }
            //percentApplicants = (sumApprovedApplicants / applicants.Count());
        }
    }
}
