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
    [Route("api/v1/AnswerHistories")]
    public class AnswerHistoriesController : ControllerBase
    {
        private readonly PDCContext _context;

        public AnswerHistoriesController(PDCContext context)
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
        // GET: api/AnswerHistories
        [HttpGet]
        public IEnumerable<tAnswerHistory> GettAnswerHistory()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return _context.tAnswerHistory.Where(ah => ah.applicant_program.applicant.client_id == Convert.ToInt32(clientID));
                }
                else { return null; }
            }
            catch { return null; }
        }

        //// GET: api/AnswerHistories/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GettAnswerHistory([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var tAnswerHistory = await _context.tAnswerHistory.SingleOrDefaultAsync(m => m.answer_history_id == id);

        //    if (tAnswerHistory == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tAnswerHistory);
        //}

        // POST: api/AnswerHistories
        [HttpPost]
        public async Task<IActionResult> PosttAnswerHistory([FromBody] tAnswerHistory tAnswerHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tAnswerHistory.Add(tAnswerHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettAnswerHistory", new { id = tAnswerHistory.answer_history_id }, tAnswerHistory);
        }

        private bool tAnswerHistoryExists(int id)
        {
            return _context.tAnswerHistory.Any(e => e.answer_history_id == id);
        }
    }
}