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
    [Route("api/Applicants")]
    public class ApplicantsController : ControllerBase
    {
        private readonly PDCContext _context;

        public ApplicantsController(PDCContext context)
        {
            _context = context;
        }

        // GET: api/Applicants
        [HttpGet]
        public IEnumerable<tApplicant> GettApplicant()
        {
            return (from a in _context.tApplicant.Include(t=> t.client)
                    select new tApplicant { applicant_id = a.applicant_id, first_name = a.first_name, last_name = a.last_name, status = a.status, email = a.email, dob = a.dob, address1 = a.address1, address2 = a.address2, address3 = a.address3, phone = a.phone, client=(from c in _context.tClient.Where(p=>p.client_id== a.client_id) select new tClient { client_id = c.client_id, client_name = c.client_name }).SingleOrDefault(), gender=a.gender }).ToList();
        }

        // GET: api/Applicants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettApplicant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var tApplicant = await _context.tApplicant.SingleOrDefaultAsync(m => m.applicant_id == id);
            //var tApplicant = await _context.tApplicant.Where(m => m.client_id == id).ToListAsync();
            var tApplicant = await (from a in _context.tApplicant.Include(t => t.client)
                                    where a.client_id == id
                                    select new tApplicant { applicant_id = a.applicant_id, first_name = a.first_name, last_name = a.last_name, status = a.status, email = a.email, dob = a.dob, address1 = a.address1, address2 = a.address2, address3 = a.address3, phone = a.phone, client = (from c in _context.tClient.Where(p => p.client_id == a.client_id) select new tClient { client_id = c.client_id, client_name = c.client_name }).SingleOrDefault(), gender = a.gender }).ToListAsync();

            if (tApplicant == null)
            {
                return NotFound();
            }

            return Ok(tApplicant);
        }

        private bool tApplicantExists(int id)
        {
            return _context.tApplicant.Any(e => e.applicant_id == id);
        }
    }
}