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
    [Route("api/v1/ProgramQuestions")]
    public class ProgramQuestionsController : ControllerBase
    {
        private readonly PDCContext _context;

        public ProgramQuestionsController(PDCContext context)
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
        // GET: api/ProgramQuestions
        [HttpGet]
        public IEnumerable<tProgramQuestion> GettProgramQuestion()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return _context.tProgramQuestion;
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

        // GET: api/ProgramQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettProgramQuestion([FromRoute] int id)
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
                { return BadRequest(ModelState); }
            }
            catch { return BadRequest(ModelState); }
            var tProgramQuestion = await _context.tProgramQuestion.SingleOrDefaultAsync(m => m.program_question_id == id);

            if (tProgramQuestion == null)
            {
                return NotFound();
            }

            return Ok(tProgramQuestion);
        }

        private bool tProgramQuestionExists(int id)
        {
            return _context.tProgramQuestion.Any(e => e.program_question_id == id);
        }
    }
}