using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tquestion")]
    public class tQuestion
    {
        [Key]
        public int question_id { get; set; }
        [Required(ErrorMessage ="Details cannot be empty")]
        [DataType(DataType.MultilineText)]
        public string question_detail { get; set; }
        [DefaultValue("Requested")]
        public string approval_status { get; set; }
        [DefaultValue("")]
        public string approved_by { get; set; }
        public DateTime approved_date { get; set; }
        [DefaultValue(0)]
        public int score { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
        public virtual ICollection<tAnswer> answers { get; set; }
    }
}
