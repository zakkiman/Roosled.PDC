using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tgroupmenu")]
    public class tGroupMenu
    {
        [Key]
        public int group_menu_id { get; set; }
        [ForeignKey("group_id")]
        public tGroup group { get; set; }
        [ForeignKey("menu_id")]
        public tMenu menu { get; set; }
    }
}
