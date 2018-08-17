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
    [Route("api/v1/Applicants")]
    public class ApplicantsController : ControllerBase
    {
        private readonly PDCContext _context;

        public ApplicantsController(PDCContext context)
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

        // GET: api/Applicants
        [HttpGet]
        public IEnumerable<tApplicant> GettApplicant()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return _context.tApplicant.Where(a => a.client_id == Convert.ToInt32(clientID));
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

        // GET: api/Applicants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettApplicant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    var tApplicant = await _context.tApplicant.SingleOrDefaultAsync(m => m.applicant_id == id && m.client_id == Convert.ToInt32(clientID));

                    if (tApplicant == null)
                    {
                        return NotFound();
                    }

                    return Ok(tApplicant);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return BadRequest(ModelState);
            }
            
        }

        // PUT: api/Applicants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttApplicant([FromRoute] int id, [FromBody] tApplicant tApplicant)
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
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == false)
                { return BadRequest(); }
            }
            catch { return BadRequest(ModelState); }
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
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == false)
                { return BadRequest(); }
                else
                {
                    var tApplicant = await _context.tApplicant.SingleOrDefaultAsync(m => m.applicant_id == id && m.client_id == Convert.ToInt32(clientID));
                    if (tApplicant == null)
                    {
                        return NotFound();
                    }

                    _context.tApplicant.Remove(tApplicant);
                    await _context.SaveChangesAsync();

                    return Ok(tApplicant);
                }
            }
            catch { return BadRequest(ModelState); }
        }

        private bool tApplicantExists(int id)
        {
            return _context.tApplicant.Any(e => e.applicant_id == id);
        }
    }
}