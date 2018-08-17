using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Controller
{
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/Batch")]
    public class BatchController : ControllerBase
    {
        private readonly PDCContext _context;

        public BatchController(PDCContext context)
        {
            _context = context;
        }

        // GET: api/Batch
        [HttpGet]
        public IEnumerable<tBatch> GettBatch()
        {
            return _context.tBatch;
        }

        // GET: api/Batch/5
        [HttpGet("{id}")]
        public async Task<Object> GettBatch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tBatch = await _context.tBatch.Where(m => m.client_id == id && m.approval_status == "Approved").ToListAsync();

            if (tBatch == null)
            {
                return NotFound();
            }

            return Ok(tBatch);
        }

        // PUT: api/Batch/5
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

        // POST: api/Batch
        [HttpPost]
        public async Task<Object> PosttBatch([FromBody] tBatch batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            batch.approval_status = "Requested";
            batch.create_by = batch.create_by;
            batch.create_date = DateTime.Now;
            batch.edit_by = batch.create_by;
            batch.edit_date = DateTime.Now;
            _context.tBatch.Add(batch);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GettBatch", new { id = batch.batch_id }, batch);
            return batch;
        }

        private bool tBatchExists(int id)
        {
            return _context.tBatch.Any(e => e.batch_id == id);
        }
    }
}