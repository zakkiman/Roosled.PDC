using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    [Table("tapplicant")]
    public class tApplicant
    {
        [Key]
        public int applicant_id { get; set; }
        [Required(ErrorMessage = "First name required")]
        public string first_name { get; set; }
        public string middle_name { get; set; }
        [Required(ErrorMessage = "Last name required")]
        public string last_name { get; set; }
        [Required]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public DateTime dob { get; set; }
        public string birth_place { get; set; }
        [ForeignKey("city_id")]
        public tCity city { get; set; }
        [Required]
        public int city_id { get; set; }
        [Required(ErrorMessage = "E-mail required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string status { get; set; }
        [Required(ErrorMessage = "Phone number required")]
        public string phone { get; set; }
        [Required(ErrorMessage ="Password cannot be empty")]
        public string password { get; set; }
        [Required(ErrorMessage = "Re-type password cannot be empty")]
        [Compare("password", ErrorMessage = "Passwords do not match.")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string confirm_password { get; set; }
        public DateTime last_login { get; set; }
        [Required]
        public int client_id { get; set; }
        [ForeignKey("client_id")]
        public tClient client { get; set; }
        [StringLength(50,ErrorMessage ="ID cannot be longer than 50 characters")]
        public string id_number { get; set; }
        [StringLength(10, ErrorMessage = "Last education cannot be longer than 10 characters")]
        public string last_education { get; set; }
        [StringLength(50, ErrorMessage = "Last education location cannot be longer than 50 characters")]
        public string last_education_location { get; set; }
        [StringLength(50, ErrorMessage = "Last job cannot be longer than 50 characters")]
        public string last_job { get; set; }
        [StringLength(50, ErrorMessage = "Last job cannot be longer than 50 characters")]
        public string last_job_location { get; set; }
        [StringLength(50, ErrorMessage = "Last job location cannot be longer than 50 characters")]
        public string position { get; set; }
        [StringLength(50, ErrorMessage = "Position cannot be longer than 50 characters")]
        public string position_location { get; set; }
        [StringLength(250, ErrorMessage = "Position cannot be longer than 250 characters")]
        public string notes { get; set; }
        public string self_opinion { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
        [NotMapped]
        public string gender_name
        {
            get
            {
                return Enum.GetName(typeof(Gender), this.gender);
            }
        }
        public string full_name { get { return string.Format("{0} {1}", first_name, last_name); } }
        public enum Gender{Male, Female};
    }
}
