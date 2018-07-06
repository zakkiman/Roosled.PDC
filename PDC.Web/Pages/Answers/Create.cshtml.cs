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
    public class CreateModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public CreateModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }
        public IList<tAnswer> answers { get; set; }
        public tQuestion question { get; set; }
        //public IActionResult OnGet()
        //{
        //    //ViewData["questions"] = new SelectList(_context.tQuestion, "question_id", "province_name");
        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            answers = await _context.tAnswer.Where(a => a.question_id == id).AsNoTracking().ToListAsync();
            question = await _context.tQuestion.SingleOrDefaultAsync(m => m.question_id == id);

            if (question == null)
            {
                return NotFound();
            }
            return Page();
        }
        [BindProperty]
        public tAnswer tAnswer { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tAnswer.question_id = (int)id;
            tAnswer.create_by = "System";
            tAnswer.create_date = DateTime.Now;
            tAnswer.edit_by = "System";
            tAnswer.edit_date = DateTime.Now;
            _context.tAnswer.Add(tAnswer);
            await _context.SaveChangesAsync();

            return Redirect("/Answers/Create?id=" + id);
        }
    }
}