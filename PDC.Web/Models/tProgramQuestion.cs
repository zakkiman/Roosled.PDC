using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tprogramquestion")]
    public class tProgramQuestion
    {
        [Key]
        public int program_question_id { get; set; }
        [ForeignKey("question_id")]
        public tQuestion question { get; set; }
        public int question_id { get; set; }
        [ForeignKey("program_id")]
        public tProgram program { get; set; }
        public int program_id { get; set; }
    }
}
