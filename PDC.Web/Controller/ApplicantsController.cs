using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Controller
{
    [Produces("application/json")]
    [Route("api/Applicants")]
    public class ApplicantsController : ControllerBase
    {
        private readonly PDCContext _context;

        public ApplicantsController(PDCContext context)
        {
            _context = context;
        }

        // GET: api/Applicants
        [HttpGet]
        public IEnumerable<tApplicant> GettApplicant()
        {
            return _context.tApplicant;
        }

        // GET: api/Applicants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettApplicant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var tApplicant = await _context.tApplicant.SingleOrDefaultAsync(m => m.applicant_id == id);
            //var tApplicant = await _context.tApplicant.Where(m => m.client_id == id).ToListAsync();
            var tApplicant = (from a in _context.tApplicant
                              where a.client_id == id && a.status == "Approved"
                              select new tApplicant { applicant_id = a.applicant_id, first_name = a.first_name, last_name = a.last_name, status = a.status, email=a.email });

            if (tApplicant == null)
            {
                return NotFound();
            }

            return Ok(tApplicant);
        }

        // PUT: api/Applicants/5
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

        // POST: api/Applicants
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

        // DELETE: api/Applicants/5
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