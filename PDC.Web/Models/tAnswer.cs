using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tanswer")]
    public class tAnswer
    {
        [Key]
        public int answer_id { get; set; }
        [Required]
        public string answer_detail { get; set; }
        [Required]
        [DefaultValue(0)]
        public int score { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
        [ForeignKey("question_id")]
        public tQuestion question { get; set; }
        public int question_id { get; set; }
    }
}
