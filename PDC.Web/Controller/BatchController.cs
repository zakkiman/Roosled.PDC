﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Controller
{
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
        public IEnumerable<tApplicantProgram> GettApplicantProgram()
        {
            return _context.tApplicantProgram;
        }

        // GET: api/Batch/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettApplicantProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tApplicantProgram = await _context.tApplicantProgram.SingleOrDefaultAsync(m => m.applicant_program_id == id);

            if (tApplicantProgram == null)
            {
                return NotFound();
            }

            return Ok(tApplicantProgram);
        }

        // PUT: api/Batch/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttApplicantProgram([FromRoute] int id, [FromBody] tApplicantProgram tApplicantProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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

        // POST: api/Batch
        [HttpPost]
        public async Task<IActionResult> PosttBatch([FromBody] tBatch batch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            batch.approval_status = "Requested";
            batch.create_by = "System";
            batch.create_date = DateTime.Now;
            batch.edit_by = "System";
            batch.edit_date = DateTime.Now;
            _context.tBatch.Add(batch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettBatch", new { id = batch.batch_id }, batch);
        }

        // DELETE: api/Batch/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetApplicantProgram([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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