using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public IndexModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public IList<tClient> tClient { get;set; }

        public async Task OnGetAsync()
        {
            tClient = await _context.tClient.ToListAsync();
        }
    }
}
