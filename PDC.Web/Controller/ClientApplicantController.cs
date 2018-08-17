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
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/ClientApplicant")]
    public class ClientApplicantController : ControllerBase
    {
        private readonly PDCContext _context;

        public ClientApplicantController(PDCContext context)
        {
            _context = context;
        }

        // GET: api/ClientApplicant
        [HttpGet]
        public IEnumerable<tApplicant> GettApplicant()
        {
            return _context.tApplicant;
        }

        // GET: api/ClientApplicant/5
        [HttpGet("{clientID}/{batchID}")]
        [Route("api/ClientApplicant/{clientID}/{batchID}")]
        public async Task<IActionResult> GettApplicant([FromRoute] int clientID, int? batchID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<tApplicant> applicant = null;
            if (batchID is null)
            {
                applicant = new List<tApplicant>();
                tApplicant a = await (from ap in _context.tApplicant
                                      select new tApplicant { address1 = ap.address1, address2 = ap.address2, address3 = ap.address3, applicant_id = ap.applicant_id, birth_place = ap.birth_place, client = (from c in _context.tClient select new tClient { client_id = c.client_id, client_name = c.client_name }).SingleOrDefault(), dob = ap.dob, email = ap.email, first_name = ap.first_name, last_name = ap.last_name }
                                      ).SingleOrDefaultAsync(m => m.client_id == clientID);
                applicant.Add(a);
            }
            else
            {
                applicant = new List<tApplicant>();
                var applicantPrograms = await _context.tApplicantProgram.Where(ap => ap.batch_id == batchID).ToListAsync();
                for(int i = 0; i < applicantPrograms.Count; i++)
                {
                    tApplicant a = await _context.tApplicant.SingleOrDefaultAsync(m => m.client_id == clientID && m.applicant_id==applicantPrograms[i].applicant_id);
                    applicant.Add(a);
                }
            }
            
            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        private bool tApplicantExists(int id)
        {
            return _context.tApplicant.Any(e => e.applicant_id == id);
        }
    }
}