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
    [Route("api/v1/Programs")]
    public class ProgramsController : ControllerBase
    {
        private readonly PDCContext _context;

        public ProgramsController(PDCContext context)
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
        // GET: api/Programs
        [HttpGet]
        public IEnumerable<tProgram> GettProgram()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return _context.tProgram;
                }
                else { return null; }
            } catch { return null; }
        }

        private bool tProgramExists(int id)
        {
            return _context.tProgram.Any(e => e.program_id == id);
        }
    }
}