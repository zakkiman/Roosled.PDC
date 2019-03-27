using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Models;

namespace PDC.Web.Pages.Reports.Preview
{
    public class CreateModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public CreateModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["answer_id"] = new SelectList(_context.tAnswer, "answer_id", "answer_detail");
        ViewData["applicant_id"] = new SelectList(_context.tApplicant, "applicant_id", "address1");
        ViewData["applicant_program_id"] = new SelectList(_context.tApplicantProgram, "applicant_program_id", "applicant_program_id");
            return Page();
        }

        [BindProperty]
        public tAppllicantAnswer tAppllicantAnswer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.tApplicantAnswer.Add(tAppllicantAnswer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}