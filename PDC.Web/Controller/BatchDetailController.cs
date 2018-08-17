using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public async Task<Object> PosttApplicantProgram([FromBody] tApplicantProgram tApplicantProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tApplicantProgram.report_description = "<h1 style=\"text-align: center;\">LAPORAN HASIL PROFILING</h1><table style=\"border-collapse: collapse;\"><tbody><tr><td style=\"width: 50%;\">Nama</td><td style=\"width: 50%;\">: {applicant_name}</td></tr><tr><td style=\"width: 50%;\">Jenis Kelamin</td><td style=\"width: 50%;\">: {gender}</td></tr><tr><td style=\"width: 50%;\">Usia</td><td style=\"width: 50%;\">: {age}</td></tr><tr><td style=\"width: 50%;\">Jabatan</td><td style=\"width: 50%;\">: {title}</td></tr></tbody></table><p><strong>I. Hasil Assestment Awal</strong></p><table style=\"border-collapse: collapse;\"><tbody><tr><td style=\"width: 50%;\">Metode&nbsp; &nbsp;&nbsp;</td><td style=\"width: 50%;\">:</td></tr><tr><td style=\"width: 50%;\">Tujuan</td><td style=\"width: 50%;\">:</td></tr></tbody></table><p>{graphic}</p><p>&lt;&lt;fill in here&gt;&gt;</p><table style=\"height: 558px; border-color: #000000; width: 781px; border-style: solid; margin-left: auto; margin-right: auto;\" border=\"1\" width=\"781\" cellspacing=\"0\" cellpadding=\"0\"><tbody><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">No</td><td style=\"height: 18px; width: 376px;\">Perilaku</td><td style=\"height: 18px; width: 68px;\">1</td><td style=\"height: 18px; width: 68px;\">2</td><td style=\"height: 18px; width: 68px;\">3</td><td style=\"height: 18px; width: 68px;\">4</td><td style=\"height: 18px; width: 70px;\">5</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 757px;\" colspan=\"7\">Favorable</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 757px;\" colspan=\"7\">Sikap kerja</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">1</td><td style=\"height: 18px; width: 376px;\">Bekerja dengan detail</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">2</td><td style=\"height: 18px; width: 376px;\">Bertanggung jawab</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">3</td><td style=\"height: 18px; width: 376px;\">Kemandirian bekerja</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">4</td><td style=\"height: 18px; width: 376px;\">Keteraturan dalam bekerja</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">5</td><td style=\"height: 18px; width: 376px;\">Kepatuhan terhadap aturan</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 36px;\"><td style=\"height: 36px; width: 27px;\">6</td><td style=\"height: 36px; width: 376px;\">Pembuatan perencanaan sebelum melaksanakan sesuatu</td><td style=\"height: 36px; width: 68px;\">&nbsp;</td><td style=\"height: 36px; width: 68px;\">&nbsp;</td><td style=\"height: 36px; width: 68px;\">&nbsp;</td><td style=\"height: 36px; width: 68px;\">&nbsp;</td><td style=\"height: 36px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">7</td><td style=\"height: 18px; width: 376px;\">Disiplin</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">8</td><td style=\"height: 18px; width: 376px;\">Loyalitas</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">9</td><td style=\"height: 18px; width: 376px;\">Motivasi kerja</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">10</td><td style=\"height: 18px; width: 376px;\">Daya saing</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 757px;\" colspan=\"7\">Kognitif</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">11</td><td style=\"height: 18px; width: 376px;\">Inisiatif</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">12</td><td style=\"height: 18px; width: 376px;\">Kreatifitas</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">13</td><td style=\"height: 18px; width: 376px;\">Kemampuan berpikir kritis</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 757px;\" colspan=\"7\">Sikap menghadapi masalah</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">14</td><td style=\"height: 18px; width: 376px;\">Keberanian menghadapi masalah</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">15</td><td style=\"height: 18px; width: 376px;\">Keberanian untuk mengungkapkan pendapat</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">16</td><td style=\"height: 18px; width: 376px;\">Kecepatan dalam membuat keputusan</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">17</td><td style=\"height: 18px; width: 376px;\">Kemampuan menerima kritik</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">18</td><td style=\"height: 18px; width: 376px;\">Kemampuan kontrol emosi</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 757px;\" colspan=\"7\">Kemampuan sosial</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">19</td><td style=\"height: 18px; width: 376px;\">Kepercayaan diri</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">20</td><td style=\"height: 18px; width: 376px;\">Kemampuan untuk mempercayai orang lain</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">21</td><td style=\"height: 18px; width: 376px;\">Keterbukaan</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">22</td><td style=\"height: 18px; width: 376px;\">Kemampuan persuasif</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">23</td><td style=\"height: 18px; width: 376px;\">Kemampuan bersosialisasi</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"height: 18px; width: 27px;\">24</td><td style=\"height: 18px; width: 376px;\">Kemampuan berempati</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 68px;\">&nbsp;</td><td style=\"height: 18px; width: 70px;\">&nbsp;</td></tr></tbody></table><p>&nbsp;</p><table style=\"border-style: solid; width: 781px; border-color: #000000; margin-left: auto; margin-right: auto; height: 118px;\" border=\"1\" width=\"693\" cellspacing=\"0\" cellpadding=\"0\"><tbody><tr style=\"height: 18px;\"><td style=\"width: 26px; height: 18px;\">No</td><td style=\"width: 384px; height: 18px;\">Perilaku</td><td style=\"width: 71px; height: 18px;\">1</td><td style=\"width: 71px; height: 18px;\">2</td><td style=\"width: 71px; height: 18px;\">3</td><td style=\"width: 71px; height: 18px;\">4</td><td style=\"width: 71px; height: 18px;\">5</td></tr><tr style=\"height: 18px;\"><td style=\"width: 777px; height: 18px;\" colspan=\"7\">Unfavorable</td></tr><tr style=\"height: 18px;\"><td style=\"width: 26px; height: 18px;\">1</td><td style=\"width: 384px; height: 18px;\">Potensi emosi meledak-ledak (borderline)</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"width: 26px; height: 18px;\">2</td><td style=\"width: 384px; height: 18px;\">Sensitivitas emosi</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"width: 26px; height: 18px;\">3</td><td style=\"width: 384px; height: 18px;\">Impulsivitas (bekerja tanpa pertimbangan matang)</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 18px;\"><td style=\"width: 26px; height: 18px;\">4</td><td style=\"width: 384px; height: 18px;\">Tingkat kecemasan</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td><td style=\"width: 71px; height: 18px;\">&nbsp;</td></tr><tr style=\"height: 10px;\"><td style=\"width: 26px; height: 10px;\">5</td><td style=\"width: 384px; height: 10px;\">Superioritas (Merasa lebih superior dari orang lain)</td><td style=\"width: 71px; height: 10px;\">&nbsp;</td><td style=\"width: 71px; height: 10px;\">&nbsp;</td><td style=\"width: 71px; height: 10px;\">&nbsp;</td><td style=\"width: 71px; height: 10px;\">&nbsp;</td><td style=\"width: 71px; height: 10px;\"><p>&nbsp;</p><p>&nbsp;</p></td></tr></tbody></table>";
            _context.tApplicantProgram.Add(tApplicantProgram);
            await _context.SaveChangesAsync();

            #region send email
            try
            {
                tApplicant applicant = await _context.tApplicant.Where(a => a.applicant_id == tApplicantProgram.applicant_id).SingleOrDefaultAsync();
                //// send email using mailjet
                //SmtpClient smtp = new SmtpClient();
                //NetworkCredential cre = new NetworkCredential();
                //cre.UserName = "27f93334bdb8f9bb088985f804619269";
                //cre.Password = "8b4359d011cc5fd1389c2c0df7f71724";
                //smtp.Credentials = cre;
                //smtp.UseDefaultCredentials = false;
                //smtp.Host = "in-v3.mailjet.com";
                //smtp.Port = 587;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.EnableSsl = true;
                //MailMessage msg = new MailMessage();
                //MailAddress mailAddress = new MailAddress("a@b.com", "Test");
                //msg.From = mailAddress;
                //msg.Body = "test";
                //msg.IsBodyHtml = true;
                //msg.Priority = MailPriority.High;
                //msg.Sender = mailAddress;
                //msg.Subject = "Test";
                //msg.To.Add(new MailAddress("ahmad.zakki@bolt.id", "Ahmad Zakki Bolt"));
                //smtp.Send(msg);
                //// end sending email using mailjet

                // send email using google
                SmtpClient smtp = new SmtpClient();
                NetworkCredential cre = new NetworkCredential();
                cre.UserName = "ahmadzakki@gmail.com";
                cre.Password = "4hmadzakk1";
                smtp.Credentials = cre;
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                MailMessage msg = new MailMessage();
                MailAddress mailAddress = new MailAddress("ahmad.zakki@bolt.id", "Demo Account");
                msg.From = mailAddress;

                if(applicant.gender== tApplicant.Gender.Female)
                {
                    msg.Body = "Yang terhormat ibu " + applicant.full_name + ",";
                }
                else
                {
                    msg.Body = "Yang terhormat";
                }
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                msg.Sender = mailAddress;
                msg.Subject = "Test";
                msg.To.Add(new MailAddress("ahmad.zakki@bolt.id", "Ahmad Zakki Bolt"));
                //smtp.Send(msg);
                //end sending email
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            #endregion

            //return CreatedAtAction("GettApplicantProgram", new { id = tApplicantProgram.applicant_program_id }, tApplicantProgram);
            return tApplicantProgram;
        }

        private bool tApplicantProgramExists(int id)
        {
            return _context.tApplicantProgram.Any(e => e.applicant_program_id == id);
        }
    }
}