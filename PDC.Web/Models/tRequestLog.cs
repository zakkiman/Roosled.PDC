using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PDC.Web.Models
{
    [Table("trequestlog")]
    public class tRequestLog
    {
        [Key]
        public int request_id { get; set; }
        [Required]
        public string request_ip { get; set; }
        [Required]
        public string request_header { get; set; }
        [Required]
        public string request_data { get; set; }
        [Required]
        public DateTime request_date { get; set; }
    }
}