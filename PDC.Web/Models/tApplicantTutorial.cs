using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tapplicanttutorial")]
    public class tApplicantTutorial
    {
        [Key]
        public int applicant_tutorial_id { get; set; }
        [Required]
        public int applicant_id { get; set; }
        [Required]
        [DefaultValue(0)]
        public byte status { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
