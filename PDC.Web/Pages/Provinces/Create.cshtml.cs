using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Models;

namespace PDC.Web.Pages.Provinces
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
        public tProvince tProvince { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tProvince.create_by = "System";
            tProvince.create_date = DateTime.Now;
            tProvince.edit_by = "System";
            tProvince.edit_date = DateTime.Now;
            _context.tProvince.Add(tProvince);
            await _context.SaveChangesAsync();
            return RedirectToPage("");
            //return RedirectToPage("./Index");
        }
    }
}