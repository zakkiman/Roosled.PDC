﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tdomain")]
    public class tDomain
    {
        [Key]
        public string domain_id { get; set; }
        [Required(ErrorMessage ="Domain name cannot be empty")]
        public string domain_name { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}
