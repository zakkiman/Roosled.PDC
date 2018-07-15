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
            ViewData["type"] = new SelectList(_context.tType, "type_name", "type_name");
            ViewData["domain"] = new SelectList(_context.tDomain, "domain_id", "domain_name");
            qCount = _context.tQuestion.Count();    
            return Page();
        }

        [BindProperty]
        public tQuestion tQuestion { get; set; }
        [BindProperty]
        public tProgramQuestion pq { get; set; }
        public int qCount { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            tProgramQuestion pquestion = new tProgramQuestion();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tQuestion.approval_status = "Approved";
            tQuestion.approved_by = "System";
            tQuestion.approved_date = DateTime.Now;
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
            for(int i = 0; i < 5; i++)
            {
                tAnswer a = new tAnswer();
                a.answer_detail = i.ToString(); ;
                a.create_by = "System";
                a.create_date = DateTime.Now;
                a.edit_by = "System";
                a.edit_date = DateTime.Now;
                a.question_id = id;
                a.score = i;
                _context.tAnswer.Add(a);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}