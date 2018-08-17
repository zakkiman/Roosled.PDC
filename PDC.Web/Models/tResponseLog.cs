using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDC.Web.Models
{
    [Table("tresponseLog")]
    public class tResponseLog
    {
        [Key]
        public int response_id { get; set; }
        [Required]
        public string request_ip { get; set; }
        [Required]
        public string response_data { get; set; }
        [Required]
        public DateTime response_date { get; set; }
    }
}