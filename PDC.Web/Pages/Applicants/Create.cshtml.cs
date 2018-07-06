using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Models;
using static PDC.Web.Models.tApplicant;

namespace PDC.Web.Pages.Applicants
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
            ViewData["client"] = new SelectList(_context.tClient, "client_id", "client_name");
            ViewData["city"] = new SelectList(_context.tCity, "city_id", "city_name");
            return Page();
        }

        [BindProperty]
        public tApplicant tApplicant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            tApplicant.create_by = "System";
            tApplicant.create_date = DateTime.Now;
            tApplicant.edit_by = "System";
            tApplicant.status = "Requested";
            tApplicant.edit_date = DateTime.Now;
            tApplicant.last_login = DateTime.MaxValue;
            _context.tApplicant.Add(tApplicant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}