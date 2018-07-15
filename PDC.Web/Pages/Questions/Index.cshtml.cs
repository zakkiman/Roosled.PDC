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

        public IList<tAnswer> tAnswer { get; set; }
        public PaginatedList<tQuestion> pageQuestion { get; set; }
        public IQueryable<tQuestion> iQ { get; set; }
        public int rowNum { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            iQ = from q in _context.tQuestion.Include(t => t.domain).Include(t => t.answers)
                 select q;
            int pageSize = 15;
            if (pageIndex is null){
                rowNum = 0;
            }
            else
            {
                rowNum = ((int)pageIndex - 1) * pageSize;
            }
            pageQuestion = await PaginatedList<tQuestion>.CreateAsync(iQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            for (int i = 0; i < pageQuestion.Count; i++)
            {
                pageQuestion[i].domain = await _context.tDomain.Where(d => d.domain_id == pageQuestion[i].domain_id).SingleOrDefaultAsync();
            }
            tAnswer = await _context.tAnswer.ToListAsync();
        }
    }
}
