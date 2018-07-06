using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tapplicanthistory")]
    public class tApplicantHistory
    {
        [Key]
        public int applicant_history_id { get; set; }
        [ForeignKey("applicant_id")]
        public tApplicant applicant { get; set; }
        [Required(ErrorMessage ="Applicant ID cannot be empty")]
        public int applicant_id { get; set; }
        [ForeignKey("client_id")]
        public tClient client { get; set; }
        [Required(ErrorMessage = "Client ID cannot be empty")]
        public int client_id { get; set; }
        public string photo { get; set; }
        public DateTime login_time { get; set; }
    }
}
