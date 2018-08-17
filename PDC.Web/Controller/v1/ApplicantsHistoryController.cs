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
    [Route("api/v1/ApplicantsHistory")]
    public class ApplicantsHistoryController : ControllerBase
    {
        private readonly PDCContext _context;

        public ApplicantsHistoryController(PDCContext context)
        {
            _context = context;
        }

        private bool isRequestValidAsync(int clientID, string apiKey)
        {
            try
            {
                tClient client = _context.tClient.SingleOrDefault(c => c.client_id == Convert.ToInt32(clientID) && c.api_key == apiKey && c.use_api == true);
                if (client == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // GET: api/ApplicantsHistory
        [HttpGet]
        public async Task<IEnumerable<tApplicantHistory>> GettApplicantHistoryAsync()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey= HttpContext.Request.Headers["apiKey"];
                if (isRequestValidAsync(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return await _context.tApplicantHistory.Where(ah => ah.client_id == Convert.ToInt32(clientID)).ToListAsync();
                }
                else { return null; }
            }
            catch { return null; }
        }

        // GET: api/ApplicantsHistory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettApplicantHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValidAsync(Convert.ToInt32(clientID), apiKey) == true)
                {
                    var tApplicantHistory = await _context.tApplicantHistory.SingleOrDefaultAsync(m => m.applicant_history_id == id);
                    if (tApplicantHistory == null)
                    {
                        return NotFound();
                    }
                    return Ok(tApplicantHistory);
                }
                else { return BadRequest(ModelState); }
            }
            catch { return BadRequest(ModelState); }
        }

        // POST: api/ApplicantsHistory
        [HttpPost]
        public async Task<IActionResult> PosttApplicantHistory([FromBody] tApplicantHistory tApplicantHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValidAsync(Convert.ToInt32(clientID), apiKey) == true)
                {
                    _context.tApplicantHistory.Add(tApplicantHistory);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GettApplicantHistory", new { id = tApplicantHistory.applicant_history_id }, tApplicantHistory);
                }
                else { return BadRequest(ModelState); }
            } catch { return BadRequest(ModelState); }
        }

        private bool tApplicantHistoryExists(int id)
        {
            return _context.tApplicantHistory.Any(e => e.applicant_history_id == id);
        }
    }
}