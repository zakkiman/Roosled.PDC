using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tprogram")]
    public class tProgram
    {
        [Key]
        public int program_id { get; set; }
        [Required(ErrorMessage ="Program name cannot be empty")]
        public string program_name { get; set; }
        [Required(ErrorMessage = "Program details cannot be empty")]
        public string program_detail { get; set; }
        [Required(ErrorMessage ="Test duration cannot be empty or 0")]
        [DefaultValue(30)]
        public int duration { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}
