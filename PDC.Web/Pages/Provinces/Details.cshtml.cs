using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Provinces
{
    public class DetailsModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DetailsModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public tProvince tProvince { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tProvince = await _context.tProvince.SingleOrDefaultAsync(m => m.province_id == id);

            if (tProvince == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
