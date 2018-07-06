using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PDC.Web.Models;

namespace PDC.Web.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public CreateModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }
        private class Area
        {
            public string Name { get; set; }
            public int Time { get; set; }
        }
        public IActionResult OnGet()
        {
            ViewData["province"] = new SelectList(_context.tProvince, "province_id", "province_name");
            
            List<Area> area = new List<Area>();
            Area a = new Area();
            a.Name = "WIB";
            a.Time = 0;
            area.Add(a);
            a = new Area();
            a.Name = "WITA";
            a.Time = 1;
            area.Add(a);
            a = new Area();
            a.Name = "WIT";
            a.Time = 2;
            area.Add(a);
            ViewData["time_area"] = new SelectList(area, "Time", "Name");
            return Page();
        }

        [BindProperty]
        public tCity tCity { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            tCity.create_by = "System";
            tCity.create_date = DateTime.Now;
            tCity.edit_by = "System";
            tCity.edit_date = DateTime.Now;
            _context.tCity.Add(tCity);
            await _context.SaveChangesAsync();
            return RedirectToPage("");
            //return RedirectToPage("./Index");
        }
    }
}