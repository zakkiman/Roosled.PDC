using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Data;
using PDC.Web.Models;

namespace PDC.Web.Pages.Batches
{
    public class CreateModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(PDC.Web.Models.PDCContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["applicants"] = new SelectList(_context.tApplicant, "applicant_id", "full_name");
            ViewData["programs"] = new SelectList(_context.tProgram, "program_id", "program_name");
            ViewData["clients"] = new SelectList(_context.tClient, "client_id", "client_name");
            var user = _userManager.GetUserName(User);
            userName = user;
            return Page();
        }

        [BindProperty]
        public tApplicantProgram tApplicantProgram { get; set; }
        [BindProperty]
        public tBatch tBatch { get; set; }
        [BindProperty]
        public string userName { get; set; }
        public IList<tApplicant> applicants { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            tBatch.approval_status = "Requested";
            _context.tBatch.Add(tBatch);
            await _context.SaveChangesAsync();
            
            return RedirectToPage("./Index");
        }
    }
}