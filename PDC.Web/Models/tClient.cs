using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tclient")]
    public class tClient
    {
        [Key]
        public int client_id { get; set; }
        [Required(ErrorMessage ="Client name required")]
        public string client_name { get; set; }
        [Required(ErrorMessage ="Address required")]
        public string address1 { get; set; }
        public string address2 { get; set; }
        [Required(ErrorMessage ="Phone required")]
        public string phone { get; set; }
        [Required(ErrorMessage ="E-mail required")]
        public string contact_email { get; set; }
        [DefaultValue(value:false)]
        public bool use_alias { get; set; }
        [DefaultValue(value: false)]
        public bool use_api { get; set; }
        public string api_key { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}
