using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    public class Batch
    {
        public string client_name { get; set; }
        public string batch_name { get; set; }
        public int program_id { get; set; }
        public int applicant_id { get; set; }
        public string approval_status { get; set; }
        public string approved_by { get; set; }
        public string approved_date { get; set; }
        public DateTime batch_start { get; set; }
        public DateTime batch_end { get; set; }
    }
}
