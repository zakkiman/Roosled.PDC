using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Models;

namespace PDC.Web.Pages.Programs
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
            return Page();
        }

        [BindProperty]
        public tProgram tProgram { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tProgram.approval_status = "Requested";
            tProgram.approved_date = DateTime.MaxValue;
            tProgram.create_by = "System";
            tProgram.create_date = DateTime.Now;
            tProgram.edit_by = "system";
            tProgram.edit_date = DateTime.Now;
            _context.tProgram.Add(tProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}