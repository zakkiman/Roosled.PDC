using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tappllicantanswer")]
    public class tAppllicantAnswer
    {
        [Key]
        public int applicant_answer_id { get; set; }
        [ForeignKey("applicant_id")]
        public tApplicant applicant { get; set; }
        [Required]
        public int applicant_id { get; set; }
        [ForeignKey("answer_id")]
        public tAnswer answer { get; set; }
        [Required]
        public int answer_id { get; set; }
        [Required]
        public DateTime selected_time { get; set; }
    }
}
