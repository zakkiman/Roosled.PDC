using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tapplicantprogram")]
    public class tApplicantProgram
    {
        [Key]
        public int applicant_program_id { get; set; }
        [Required]
        public int applicant_id { get; set; }
        [ForeignKey("applicant_id")]
        public tApplicant applicant { get; set; }
        [Required]
        public int program_id { get; set; }
        [ForeignKey("program_id")]
        public tProgram program { get; set; }
        [Required(ErrorMessage ="Batch name cannot be empty")]
        public string batch_name { get; set; }
        [DefaultValue("Requested")]
        public string approval_status { get; set; }
        public string approved_by { get; set; }
        public string approved_date { get; set; }
        public DateTime batch_start { get; set; }
        public DateTime batch_end { get; set; }
    }
}