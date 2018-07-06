﻿using System;
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
        public string type_name { get; set; }
        [Required(ErrorMessage ="Alias cannot be empty")]
        public string type_alias { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}