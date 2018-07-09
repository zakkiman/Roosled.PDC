using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PDC.Web.Models.tApplicant;

namespace PDC.Web.Models
{
    public class ClientApplicantProgram
    {
        public int id { get; set; }
        public int client_id { get; set; }
        public string client_name { get; set; }
        public int applicant_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int program_id { get; set; }
        public string program_name { get; set; }
        public int batch_id { get; set; }
        public string batch_name { get; set; }
        public string status { get; set; }
        public string approved_by { get; set; }
        public string approved_date { get; set; }
        public Gender gender { get; set; }
        public DateTime dob { get; set; }
        public DateTime batch_start { get; set; }
        public DateTime batch_end { get; set; }

        public static explicit operator ClientApplicantProgram(Task<List<object>> v)
        {
            throw new NotImplementedException();
        }
    }
}
