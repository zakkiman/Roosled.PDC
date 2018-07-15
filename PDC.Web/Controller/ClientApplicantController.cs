using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Controller
{
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
                tApplicant a= await _context.tApplicant.SingleOrDefaultAsync(m => m.client_id == clientID);
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

        // PUT: api/ClientApplicant/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttApplicant([FromRoute] int id, [FromBody] tApplicant tApplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tApplicant.applicant_id)
            {
                return BadRequest();
            }

            _context.Entry(tApplicant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tApplicantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClientApplicant
        [HttpPost]
        public async Task<IActionResult> PosttApplicant([FromBody] tApplicant tApplicant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tApplicant.Add(tApplicant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettApplicant", new { id = tApplicant.applicant_id }, tApplicant);
        }

        // DELETE: api/ClientApplicant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetApplicant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tApplicant = await _context.tApplicant.SingleOrDefaultAsync(m => m.applicant_id == id);
            if (tApplicant == null)
            {
                return NotFound();
            }

            _context.tApplicant.Remove(tApplicant);
            await _context.SaveChangesAsync();

            return Ok(tApplicant);
        }

        private bool tApplicantExists(int id)
        {
            return _context.tApplicant.Any(e => e.applicant_id == id);
        }
    }
}