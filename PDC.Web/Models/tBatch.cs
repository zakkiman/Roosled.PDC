using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tbatch")]
    public class tBatch
    {
        [Key]
        public int batch_id { get; set; }
        [Required(ErrorMessage = "Batch name cannot be empty")]
        [StringLength(50, ErrorMessage = "Batch name cannot be longer than 50 characters")]
        public string batch_name { get; set; }
        [DefaultValue("Requested")]
        [StringLength(20)]
        public string approval_status { get; set; }
        [StringLength(50)]
        public string approved_by { get; set; }
        public string approved_date { get; set; }
        [DefaultValue(false)]
        public bool isExpired { get; set; }
        [ForeignKey("client_id")]
        public tClient client { get; set; }
        public int client_id { get; set; }
        public DateTime batch_start { get; set; }
        public DateTime batch_end { get; set; }
        [StringLength(50)]
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        [StringLength(50)]
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }

        public virtual IList<tApplicantProgram> applicantPrograms { get; set; }
    }
}
