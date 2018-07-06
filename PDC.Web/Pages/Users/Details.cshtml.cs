using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public DetailsModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public tUser tUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            tUser = await _context.tUser.SingleOrDefaultAsync(m => m.user_id == id);

            if (tUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
