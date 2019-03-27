using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Reports
{
    public class PreviewModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;
        public PreviewModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }
        public tApplicantProgram tApplicantProgram { get; set; }
        public IList<tType> types { get; set; }
        public IList<tDomain> domains { get; set; }
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
        public tApplicant applicant { get; set; }
        public IList<tAppllicantAnswer> answers { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id, int? app)
        {
            string applicantName = "";
            if (id == null && app == null)
            {
                return NotFound();
            }

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
            tApplicantProgram = await _context.tApplicantProgram
                .Include(t => t.applicant)
                .Include(t => t.batch)
                .Include(t => t.program).SingleOrDefaultAsync(m => m.applicant_program_id == id);
            //applicant = await _context.tApplicant.Include(t => t.client).Where(a => a.applicant_id == app).SingleOrDefaultAsync();
            applicantName = tApplicantProgram.applicant.full_name;
            // ranking process
            int sort = 1;
            rangkings = new List<rangking>();
            rangking bRank = new rangking();
            foreach (tType t in types)
            {
                List<tAppllicantAnswer> lap = answers.Where(a => a.answer.question.type_name == t.type_name).ToList();
                rangking r = new rangking();
                r.rankID = sort;
                foreach (tAppllicantAnswer ap in lap)
                {
                    r.rawScore += ap.answer.score;
                }
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
            }
            rangkings = rangkings.OrderByDescending(o => o.zScore).ToList();
            int age = 0;
            int years = DateTime.Now.Year - tApplicantProgram.applicant.dob.Year;
            DateTime birthdayThisYear = tApplicantProgram.applicant.dob.AddYears(years);
            string graphic = "<div class=\"col-md-12\"><div class=\"row\"><div class=\"col-md-12\"> <canvas id=\"canvas\" width=\"450\" height=\"200\"></canvas></div></div><div class=\"row\"><div class=\"col-md-12\"><h4>Evolutionary and Domain Personality :</h4><table style=\"border: 1px solid #ddd;width:100%;max-width:100%;margin-bottom:20px;\" title=\"\"><thead><tr style=\"background-color:#000; color:#fff; font-size:.9em; text-align:center; width:50%\"><td>Personality</td><td>Pain >< Pleasure</td><td>Passive >< Active</td><td>Self >< Other</td><td>Score</td></tr></thead><tbody>";
            for (int i = 0; i < 4; i++)
            {
                graphic += "<tr style=\"text-align:center;\">";
                graphic += "<td>" + rangkings[i].type.type_name + "</td>";
                graphic += "<td>" + rangkings[i].type.pain_pleasure + "</td>";
                graphic += "<td>" + rangkings[i].type.passive_active + "</td>";
                graphic += "<td>" + rangkings[i].type.self_other + "</td>";
                graphic += "<td>" + rangkings[i].zScore.ToString("#.###0") + "</td>";
            }
            graphic += "</tbody></table></div></div></div>";
            age = birthdayThisYear > DateTime.Now ? years - 1 : years;
            tApplicantProgram.report_description = tApplicantProgram.report_description.Replace("{applicant_name}", tApplicantProgram.applicant.full_name);
            tApplicantProgram.report_description = tApplicantProgram.report_description.Replace("{gender}", tApplicantProgram.applicant.gender.ToString());
            tApplicantProgram.report_description = tApplicantProgram.report_description.Replace("{age}", age.ToString());
            tApplicantProgram.report_description = tApplicantProgram.report_description.Replace("{graphic}", graphic);

            if (tApplicantProgram == null)
            {
                return NotFound();
            }
            //var report = new Rotativa.NetCore.ActionAsPdf("OnGetAsync");
            //return report;
            return Page();
        }
    }
}