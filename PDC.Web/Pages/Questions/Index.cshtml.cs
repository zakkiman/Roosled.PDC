using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public IndexModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public IList<tQuestion> tQuestion { get;set; }
        public IList<tAnswer> tAnswer { get; set; }

        public async Task OnGetAsync()
        {
            tQuestion = await _context.tQuestion.ToListAsync();
            tAnswer = await _context.tAnswer.ToListAsync();
        }
    }
}
