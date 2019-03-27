using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Reports.Preview
{
    public class ScoreModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public ScoreModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        [BindProperty]
        public tApplicantProgram applicantProgram { get; set; }
        public IList<tAppllicantAnswer> answers { get; set; }
        public IList<tAnswerHistory> history { get; set; }
        public IList<tType> types { get; set; }
        public IList<tDomain> domains { get; set; }
        public tApplicant applicant { get; set; }
        public IList<tApplicantHistory> applicantHistory { get; set; }
        public class rangking
        {
            public int rankID { get; set; }
            public tType type { get; set; }
            public decimal rawScore { get; set; }
            public decimal zScore { get; set; }
            public List<domainCount> domainCount { get; set; }
        }
        public class domainCount
        {
            public int count { get; set; }
            public tDomain domain { get; set; }
        }
        public List<rangking> rangkings { get; set; }
        public static tApplicantProgram ap;
        public async Task<IActionResult> OnGetAsync(int? id, int? app)
        {
            if (id == null && app == null)
            {
                return NotFound();
            }
            applicantHistory = await _context.tApplicantHistory.Where(h => h.applicant_id == app).ToListAsync();
            applicantProgram = await _context.tApplicantProgram.Where(m => m.applicant_program_id == id).SingleOrDefaultAsync();
            ap = applicantProgram;
            types = await _context.tType.ToListAsync();
            domains = await _context.tDomain.ToListAsync();
            answers = await _context.tApplicantAnswer
                .Include(t => t.answer.question)
                .Include(t => t.answer.question.domain)
                .Include(t => t.answer.question.type)
                .Include(t => t.answer)
                .Include(t => t.applicant_program)
                .Include(t => t.applicant_program.batch)
                .Include(t => t.applicant_program.batch.client)
                .Where(ap => ap.applicant_program.applicant_program_id == id && ap.applicant_id == app).ToListAsync();
            history = await _context.tAnswerHistory
                .Include(t => t.answer)
                .Include(t => t.answer.question)
                .Where(h => h.applicant_program.applicant_id == app && h.applicant_program.applicant_program_id == id).ToListAsync();
            applicant = await _context.tApplicant.Include(t => t.client).Where(a => a.applicant_id == app).SingleOrDefaultAsync();

            // ranking process
            int sort = 1;
            rangkings = new List<rangking>();
            rangking bRank = new rangking();
            foreach (tType t in types)
            {
                rangking r = new rangking();
                r.rankID = sort;

                List<tAppllicantAnswer> lap = answers.Where(a => a.answer.question.type_name == t.type_name).ToList();
                foreach (tAppllicantAnswer ap in lap)
                {
                    if (ap.answer.question.isBorderline == true)
                    {
                        bRank.rawScore += ap.answer.score;
                    }
                    r.rawScore += ap.answer.score;
                }
                r.type = new tType();
                r.type = t;
                r.zScore = (r.rawScore - t.substractor) / t.divider;
                r.domainCount = new List<domainCount>();
                foreach (tDomain d in domains)
                {
                    domainCount dc = new domainCount();
                    dc.count = answers.Where(a => a.answer.question.type_name == t.type_name && a.answer.question.domain.domain_id == d.domain_id && a.answer.score > 2).Count();
                    dc.domain = new tDomain();
                    dc.domain = d;
                    r.domainCount.Add(dc);
                }
                if (t.type_name == "Borderline")
                {
                    r.type = new tType();
                    r.type = t;
                    r.zScore = (bRank.rawScore - t.substractor) / t.divider;
                    r.rawScore = bRank.rawScore;
                    r.domainCount = new List<domainCount>();
                    foreach (tDomain d in domains)
                    {
                        domainCount dc = new domainCount();
                        dc.count = answers.Where(a => a.answer.question.isBorderline == true && a.answer.question.domain.domain_id == d.domain_id && a.answer.score > 2).Count();
                        dc.domain = new tDomain();
                        dc.domain = d;
                        r.domainCount.Add(dc);
                    }
                }
                rangkings.Add(r);
                sort++;
                //}
            }
            rangkings = rangkings.OrderByDescending(o => o.zScore).ToList();

            if (answers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
