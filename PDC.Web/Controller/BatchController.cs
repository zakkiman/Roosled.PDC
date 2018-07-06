using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> PosttApplicantProgram([FromBody] tApplicantProgram tApplicantProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.tApplicantProgram.Add(tApplicantProgram);
            await _context.SaveChangesAsync();

            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.DeliveryFormat = SmtpDeliveryFormat.International;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Host = "smtp-relay.sendinblue.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("ruby.sastro@gmail.com", "OLGQ8wXRhBICAbrK");
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    var msg = new MailMessage
                    {
                        Body = "",
                        Subject = "Invitation",
                        From = new MailAddress("someone@somewhere.com", "Someone at Somewhere")
                    };
                    //msg.To.Add(new MailAddress(tApplicant.email, tApplicant.full_name));
                    msg.To.Add(new MailAddress("ahmad.zakki@bolt.id", "Ahmad Zakki"));
                    msg.Subject = "Test subject";
                    msg.IsBodyHtml = true;
                    msg.Priority = MailPriority.High;
                    smtp.Send(msg);
                }
            }
            catch (Exception ex)
            {

            }

            return CreatedAtAction("GettApplicantProgram", new { id = tApplicantProgram.applicant_program_id }, tApplicantProgram);
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