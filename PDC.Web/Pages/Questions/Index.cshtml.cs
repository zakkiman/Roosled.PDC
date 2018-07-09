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
        public IList<tQuestion> tq { get; set; }
        public IList<tAnswer> tAnswer { get; set; }
        public tDomain domain { get; set; }

        public async Task OnGetAsync()
        {
            tQuestion = await _context.tQuestion.ToListAsync();
            for(int i = 0; i < tQuestion.Count; i++)
            {
                tQuestion[i].domain = await _context.tDomain.Where(d => d.domain_id == tQuestion[i].domain_id).SingleOrDefaultAsync();
            }
            tAnswer = await _context.tAnswer.ToListAsync();
        }
    }
}
