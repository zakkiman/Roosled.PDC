using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Controller
{   [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/ApplicantPrograms")]
    public class ApplicantProgramsController : ControllerBase
    {
        private readonly PDCContext _context;

        public ApplicantProgramsController(PDCContext context)
        {
            _context = context;
        }

        // GET: api/ApplicantPrograms
        [HttpGet]
        public IEnumerable<tApplicantProgram> GettApplicantProgram()
        {
            return _context.tApplicantProgram;
        }

        // GET: api/ApplicantPrograms/5
        [HttpGet("{id}")]
        [Route("api/ApplicantProgram/{id}")]
        public async Task<object> GettApplicantProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var tApplicantProgram = await _context.tApplicantProgram.Include(t=> t.applicant).SingleOrDefaultAsync(m => m.applicant_program_id == id && m.applicant_id == applicantID);
            var tApplicantProgram = await (from ap in _context.tApplicantProgram
                                           select new tApplicantProgram { applicant = (from a in _context.tApplicant select new tApplicant { applicant_id = a.applicant_id, client_id = a.client_id, first_name = a.full_name, email = a.email, dob = a.dob }).SingleOrDefault(p => p.applicant_id == ap.applicant_id), batch_id = ap.batch_id, program_id = ap.program_id, applicant_program_id = ap.applicant_program_id, applicant_id = ap.applicant_id }
                                           ).Where(m => m.batch_id == id).ToListAsync();

            if (tApplicantProgram == null)
            {
                return NotFound();
            }

            return Ok(tApplicantProgram);
        }

        private bool tApplicantProgramExists(int id)
        {
            return _context.tApplicantProgram.Any(e => e.applicant_program_id == id);
        }
    }
}