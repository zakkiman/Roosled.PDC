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
    [Route("api/v1/Questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly PDCContext _context;

        public QuestionsController(PDCContext context)
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
        // GET: api/Questions
        [HttpGet]
        public IEnumerable<tQuestion> GettQuestion()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    var questions = (from b in _context.tQuestion
                                     select new tQuestion { answers = _context.tAnswer.Where(a => a.question_id == b.question_id).ToList(), approval_status = b.approval_status, approved_by = b.approved_by, approved_date = b.approved_date, create_by = b.create_by, create_date = b.create_date, question_detail = b.question_detail, question_id = b.question_id, score = b.score });
                    return questions;
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

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettQuestion([FromRoute] int id)
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
            } catch { return BadRequest(ModelState); }
            var tQuestion = await (from b in _context.tQuestion
                                   select new tQuestion { answers = _context.tAnswer.Where(a => a.question_id == b.question_id).ToList(), approval_status = b.approval_status, approved_by = b.approved_by, approved_date = b.approved_date, create_by = b.create_by, create_date = b.create_date, question_detail = b.question_detail, question_id = b.question_id, score = b.score }).SingleOrDefaultAsync(m => m.question_id == id);

            if (tQuestion == null)
            {
                return NotFound();
            }

            return Ok(tQuestion);
        }

        private bool tQuestionExists(int id)
        {
            return _context.tQuestion.Any(e => e.question_id == id);
        }
    }
}