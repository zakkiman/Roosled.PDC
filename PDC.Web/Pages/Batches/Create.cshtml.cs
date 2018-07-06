using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PDC.Web.Models;

namespace PDC.Web.Pages.Batches
{
    public class CreateModel : PageModel
    {
        private readonly PDC.Web.Models.PDCContext _context;

        public CreateModel(PDC.Web.Models.PDCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["applicants"] = new SelectList(_context.tApplicant, "applicant_id", "full_name");
            ViewData["programs"] = new SelectList(_context.tProgram, "program_id", "program_name");
            ViewData["clients"] = new SelectList(_context.tClient, "client_id", "client_name");
            return Page();
        }

        [BindProperty]
        public tApplicantProgram tApplicantProgram { get; set; }
        public IList<tApplicant> applicants { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            tApplicantProgram.approval_status = "Requested";
            _context.tApplicantProgram.Add(tApplicantProgram);
            await _context.SaveChangesAsync();
            //send e-mail
            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.DeliveryFormat = SmtpDeliveryFormat.International;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Host = "smtp-relay.sendinblue.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("ruby.sastro@gmail.com", "OLGQ8wXRhBICAbrK");
                    smtp.EnableSsl = false;
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
            //end
            return RedirectToPage("./Index");
        }
    }
}