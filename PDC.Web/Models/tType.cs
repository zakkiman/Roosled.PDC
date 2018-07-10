using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("ttype")]
    public class tType
    {
        [Key]
        [Required(ErrorMessage ="Type name cannot be empty")]
        [StringLength(50)]
        public string type_name { get; set; }
        [Required(ErrorMessage ="Alias cannot be empty")]
        [StringLength(50)]
        public string type_alias { get; set; }
        public bool display { get; set; }
        public bool auto_display { get; set; }
        public decimal substractor { get; set; }
        public decimal divider { get; set; }
        [StringLength(50)]
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        [StringLength(50)]
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}
