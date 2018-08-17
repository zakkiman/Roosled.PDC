using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tconfiguration")]
    public class tConfiguration
    {
        [Key]
        [StringLength(50)]
        [Display(Name = "Configuration Name")]
        [Required(ErrorMessage = "Configuration name cannot be empty")]
        public string config_name { get; set; }
        [StringLength(150)]
        [Display(Name = "E-mail Name")]
        [Required(ErrorMessage = "E-mail name cannot be empty")]
        public string email_name { get; set; }
        [StringLength(150)]
        [Display(Name = "E-mail Address")]
        [Required(ErrorMessage = "E-mail address cannot be empty")]
        public string email_address { get; set; }
        [StringLength(150)]
        [Display(Name = "SMTP Host")]
        [Required(ErrorMessage = "SMTP host name cannot be empty")]
        public string smtp_host { get; set; }
        [Display(Name = "SMTP Port")]
        [Required(ErrorMessage = "SMTP port cannot be empty")]
        public int smtp_port { get; set; }
        [Display(Name = "Secure ?")]
        public bool is_secure { get; set; }
        [Display(Name = "E-mail body template")]
        [Required]
        public string email_tempate { get; set; }
    }
}
