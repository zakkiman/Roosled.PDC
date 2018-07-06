using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tcity")]
    public class tCity
    {
        [Key]
        public int city_id { get; set; }
        [Required]
        public string city_name { get; set; }
        [ForeignKey("province_id")]
        public tProvince province { get; set; }
        [Required]
        [DefaultValue(0)]
        public int time_area { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}
