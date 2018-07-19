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
        [Required]
        public int batch_id { get; set; }
        [ForeignKey("batch_id")]
        public tBatch batch { get; set; }
        [DefaultValue("-")]
        public string report_description { get; set; }
    }
}