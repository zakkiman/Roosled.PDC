using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Models;

namespace PDC.Web.Pages.Questions
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
            ViewData["program"] = new SelectList(_context.tProgram, "program_id", "program_name");
            return Page();
        }

        [BindProperty]
        public tQuestion tQuestion { get; set; }
        [BindProperty]
        public tProgramQuestion pq { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            tProgramQuestion pquestion = new tProgramQuestion();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tQuestion.approval_status = "Requested";
            tQuestion.approved_by = "";
            tQuestion.approved_date = DateTime.MaxValue;
            tQuestion.create_by = "System";
            tQuestion.create_date = DateTime.Now;
            tQuestion.edit_by = "System";
            tQuestion.edit_date = DateTime.Now;
            _context.tQuestion.Add(tQuestion);
            _context.SaveChanges();
            // id after insert question
            int id = tQuestion.question_id;
            pquestion.question_id = id;
            pquestion.program_id = pq.program_id;
            _context.tProgramQuestion.Add(pquestion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}