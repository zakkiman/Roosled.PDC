using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tmenu")]
    public class tMenu
    {
        [Key]
        public int menu_id { get; set; }
        [Required]
        public string menu_name { get; set; }
        [DefaultValue(false)]
        public bool is_parent { get; set; }
        [DefaultValue(0)]
        public int parent_id { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}
