using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Models;

namespace PDC.Web.Pages.Groups
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
        public tGroup tGroup { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            tGroup.create_by = "System";
            tGroup.create_date = DateTime.Now;
            tGroup.edit_by = "System";
            tGroup.edit_date = DateTime.Now;
            _context.tGroup.Add(tGroup);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}