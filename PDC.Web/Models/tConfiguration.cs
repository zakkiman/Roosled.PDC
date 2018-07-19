using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    public class tConfiguration
    {
        [Key]
        public int config_id { get; set; }
        [Required(ErrorMessage ="Email template cannot be empty")]
        public string email_template { get; set; }
        [Required(ErrorMessage ="Email login cannot be empty")]
        [MaxLength(60)]
        public string email_login_id { get; set; }

    }
}
