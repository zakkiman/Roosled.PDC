using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Controller.v1
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/v1/ApplicantPrograms")]
    public class ApplicantProgramsController : ControllerBase
    {
        private readonly PDCContext _context;

        public ApplicantProgramsController(PDCContext context)
        {
            _context = context;
        }

        private bool isRequestValid(int clientID, string apiKey)
        {
            try
            {
                tClient client = _context.tClient.SingleOrDefault(c => c.client_id == Convert.ToInt32(clientID) && c.api_key == apiKey && c.use_api == true);
                if (client == null) { return false; } else { return true; }
            }
            catch { return false; }
        }

        // GET: api/ApplicantProgram
        [HttpGet]
        public IEnumerable<tApplicantProgram> GettApplicantProgram()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return (from baru in _context.tApplicantProgram.Include(t => t.applicant).Where(a => a.applicant.client_id == Convert.ToInt32(clientID))
                            select new tApplicantProgram() { applicant_id = baru.applicant_id, applicant_program_id = baru.applicant_program_id, batch_id = baru.batch_id, program_id = baru.program_id });
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        // GET: api/ApplicantProgram/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettApplicantProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == false)
                { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }
            var tApplicantProgram = await _context.tApplicantProgram.SingleOrDefaultAsync(m => m.applicant_program_id == id);

            if (tApplicantProgram == null)
            {
                return NotFound();
            }

            return Ok(tApplicantProgram);
        }

        // PUT: api/ApplicantProgram/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttApplicantProgram([FromRoute] int id, [FromBody] tApplicantProgram tApplicantProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == false)
                { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }
            if (id != tApplicantProgram.applicant_program_id)
            {
                return BadRequest();
            }

            _context.Entry(tApplicantProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tApplicantProgramExists(id))
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

        // POST: api/ApplicantProgram
        [HttpPost]
        public async Task<IActionResult> PosttApplicantProgram([FromBody] tApplicantProgram tApplicantProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == false)
                { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }
            _context.tApplicantProgram.Add(tApplicantProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettApplicantProgram", new { id = tApplicantProgram.applicant_program_id }, tApplicantProgram);
        }

        // DELETE: api/ApplicantProgram/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetApplicantProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == false)
                { return BadRequest(); }
            }
            catch
            {
                return BadRequest();
            }
            var tApplicantProgram = await _context.tApplicantProgram.SingleOrDefaultAsync(m => m.applicant_program_id == id);
            if (tApplicantProgram == null)
            {
                return NotFound();
            }

            _context.tApplicantProgram.Remove(tApplicantProgram);
            await _context.SaveChangesAsync();

            return Ok(tApplicantProgram);
        }

        private bool tApplicantProgramExists(int id)
        {
            return _context.tApplicantProgram.Any(e => e.applicant_program_id == id);
        }
    }
}