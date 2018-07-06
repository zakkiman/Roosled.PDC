using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tgroup")]
    public class tGroup
    {
        [Key]
        public int group_id { get; set; }
        [Required]
        public string group_name { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_answer { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_answer { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_answer { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_applicant { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_applicant { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_applicant { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_city { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_city { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_city { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_client { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_client { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_client { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_group { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_group { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_group { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_menu { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_menu { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_menu { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_program { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_program { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_program { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool approve_program { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_province { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_province { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_province { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_question { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_question { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_question { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool approve_question { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_user { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_user { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_user { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool add_batch { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool edit_batch { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool delete_batch { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool approve_batch { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
    }
}
