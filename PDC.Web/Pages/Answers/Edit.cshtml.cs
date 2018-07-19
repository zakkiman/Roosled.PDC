using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Answers
{
    public class EditModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public EditModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tAnswer tAnswer { get; set; }
        public static tAnswer answer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tAnswer = await _context.tAnswer.SingleOrDefaultAsync(m => m.answer_id == id);
            answer = tAnswer;
            if (tAnswer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int ID)
        {
            tAnswer.create_by = answer.create_by;
            tAnswer.create_date = answer.create_date;
            tAnswer.edit_by = "System";
            tAnswer.edit_date = DateTime.Now;
            tAnswer.question_id = answer.question_id;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(tAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tAnswerExists(tAnswer.answer_id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Questions");
        }

        private bool tAnswerExists(int id)
        {
            return _context.tAnswer.Any(e => e.answer_id == id);
        }
    }
}
