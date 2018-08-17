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
    [Route("api/v1/Batches")]
    public class BatchesController : ControllerBase
    {
        private readonly PDCContext _context;

        public BatchesController(PDCContext context)
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

        // GET: api/Batches
        [HttpGet]
        public IEnumerable<tBatch> GettBatch()
        {
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == true)
                {
                    return _context.tBatch.Where(b => b.client_id == Convert.ToInt32(clientID));
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

        // GET: api/Batches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettBatch([FromRoute] int id)
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
            var tBatch = await _context.tBatch.SingleOrDefaultAsync(m => m.batch_id == id);

            if (tBatch == null)
            {
                return NotFound();
            }

            return Ok(tBatch);
        }

        // PUT: api/Batches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttBatch([FromRoute] int id, [FromBody] tBatch tBatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBatch.batch_id)
            {
                return BadRequest();
            }
            try
            {
                string clientID = HttpContext.Request.Headers["clientID"];
                string apiKey = HttpContext.Request.Headers["apiKey"];
                if (isRequestValid(Convert.ToInt32(clientID), apiKey) == false)
                { return BadRequest(); }
            }
            catch { return BadRequest(ModelState); }
            _context.Entry(tBatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tBatchExists(id))
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

        // POST: api/Batches
        [HttpPost]
        public async Task<IActionResult> PosttBatch([FromBody] tBatch tBatch)
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
            _context.tBatch.Add(tBatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettBatch", new { id = tBatch.batch_id }, tBatch);
        }

        private bool tBatchExists(int id)
        {
            return _context.tBatch.Any(e => e.batch_id == id);
        }
    }
}