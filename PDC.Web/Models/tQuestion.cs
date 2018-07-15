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
        [StringLength(20)]
        public string approval_status { get; set; }
        [DefaultValue("")]
        [StringLength(50)]
        public string approved_by { get; set; }
        public DateTime approved_date { get; set; }
        [ForeignKey("type_name")]
        public tType type { get; set; }
        [Required(ErrorMessage = "Type cannot be empty")]
        [DefaultValue("Avoid")]
        [StringLength(50)]
        public string type_name { get; set; }
        [ForeignKey("domain_id")]
        public tDomain domain { get; set; }
        [Required(ErrorMessage = "Domain cannot be empty")]
        public int domain_id { get; set; }
        [DefaultValue(0)]
        public int score { get; set; }
        [StringLength(50)]
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        [StringLength(50)]
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
        [DefaultValue(value: false)]
        public bool? isBorderline { get; set; }
        public virtual ICollection<tAnswer> answers { get; set; }
    }
}
