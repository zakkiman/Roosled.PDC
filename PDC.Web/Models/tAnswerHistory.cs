using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tanswerhistory")]
    public class tAnswerHistory
    {
        [Key]
        public int answer_history_id { get; set; }
        [Required]
        public tAnswer answer { get; set; }
        [Required]
        public int answer_id { get; set; }
        [Required]
        public DateTime selected_time { get; set; }
        [ForeignKey("applicant_program_id")]
        public tApplicantProgram applicant_program { get; set; }
        public int applicant_program_id { get; set; }
    }
}
