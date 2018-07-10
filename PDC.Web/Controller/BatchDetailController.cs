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
    [Route("api/BatchDetail")]
    public class BatchDetailController : ControllerBase
    {
        private readonly PDCContext _context;

        public BatchDetailController(PDCContext context)
        {
            _context = context;
        }

        // GET: api/BatchDetail
        [HttpGet]
        public IEnumerable<tApplicantProgram> GettApplicantProgram()
        {
            return _context.tApplicantProgram;
        }

        // GET: api/BatchDetail/5
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

        // PUT: api/BatchDetail/5
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

        // POST: api/BatchDetail
        [HttpPost]
        public async Task<IActionResult> PosttApplicantProgram([FromBody] tApplicantProgram tApplicantProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tApplicantProgram.Add(tApplicantProgram);
            await _context.SaveChangesAsync();

            SmtpClient smtp = new SmtpClient();
            NetworkCredential cre = new NetworkCredential();
            cre.UserName = "27f93334bdb8f9bb088985f804619269";
            cre.Password = "8b4359d011cc5fd1389c2c0df7f71724";
            smtp.Credentials = cre;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "in-v3.mailjet.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            MailAddress mailAddress = new MailAddress("a@b.com", "Test");
            msg.From = mailAddress;
            msg.Body = "test";
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            msg.Sender = mailAddress;
            msg.Subject = "Test";
            msg.To.Add(new MailAddress("ahmad.zakki@bolt.id", "Ahmad Zakki Bolt"));
            //smtp.Send(msg);

            return CreatedAtAction("GettApplicantProgram", new { id = tApplicantProgram.applicant_program_id }, tApplicantProgram);
        }

        // DELETE: api/BatchDetail/5
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