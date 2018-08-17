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
    [Route("api/v1/AppllicantAnswers")]
    public class AppllicantAnswersController : ControllerBase
    {
        private readonly PDCContext _context;

        public AppllicantAnswersController(PDCContext context)
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
        // GET: api/AppllicantAnswers
        [HttpGet]
        public IEnumerable<tAppllicantAnswer> GettApplicantAnswer()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return _context.tApplicantAnswer.Where(aa => aa.applicant.client_id == Convert.ToInt32(clientID));
                }
                else { return null; }
            }
            catch { return null; }
            
        }

        // GET: api/AppllicantAnswers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettAppllicantAnswer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tAppllicantAnswer = await _context.tApplicantAnswer.SingleOrDefaultAsync(m => m.applicant_answer_id == id);

            if (tAppllicantAnswer == null)
            {
                return NotFound();
            }

            return Ok(tAppllicantAnswer);
        }

        // PUT: api/AppllicantAnswers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttAppllicantAnswer([FromRoute] int id, [FromBody] tAppllicantAnswer tAppllicantAnswer)
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
            if (id != tAppllicantAnswer.applicant_answer_id)
            {
                return BadRequest();
            }

            _context.Entry(tAppllicantAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tAppllicantAnswerExists(id))
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

        // POST: api/AppllicantAnswers
        [HttpPost]
        public async Task<IActionResult> PosttAppllicantAnswer([FromBody] tAppllicantAnswer tAppllicantAnswer)
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
            _context.tApplicantAnswer.Add(tAppllicantAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettAppllicantAnswer", new { id = tAppllicantAnswer.applicant_answer_id }, tAppllicantAnswer);
        }

        private bool tAppllicantAnswerExists(int id)
        {
            return _context.tApplicantAnswer.Any(e => e.applicant_answer_id == id);
        }
    }
}