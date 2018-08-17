using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    public class SubmitData
    {
        public int client_id { get; set; }
        public string api_key { get; set; }
        public DateTime request_date { get; set; }
    }
}
