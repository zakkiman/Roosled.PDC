using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Questions
{
    public class EditModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public EditModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tQuestion tQuestion { get; set; }
        public static tQuestion oldQuestion { get; set; }
        [BindProperty]
        public tProgramQuestion pq { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tQuestion = await _context.tQuestion.SingleOrDefaultAsync(m => m.question_id == id);
            oldQuestion = tQuestion;
            ViewData["program"] = new SelectList(_context.tProgram, "program_id", "program_name");
            ViewData["type"] = new SelectList(_context.tType, "type_name", "type_name");
            ViewData["domain"] = new SelectList(_context.tDomain, "domain_id", "domain_name");

            if (tQuestion == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(tQuestion).State = EntityState.Modified;
            tQuestion.edit_by = "System";
            tQuestion.edit_date = DateTime.Now;
            tQuestion.create_by = oldQuestion.create_by;
            tQuestion.create_date = oldQuestion.create_date;
            tQuestion.approval_status = "Approved";
            tQuestion.approved_by = "System";
            tQuestion.approved_date = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tQuestionExists(tQuestion.question_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool tQuestionExists(int id)
        {
            return _context.tQuestion.Any(e => e.question_id == id);
        }
    }
}
