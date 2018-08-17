using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PDC.Web.Models
{
    public class Encryption
    {
        
    }
    [Table("tuser")]
    public class tUser
    {
        [Key]
        [Required(ErrorMessage = "User ID cannot be empty")]
        public string user_id { get; set; }
        [Required(ErrorMessage ="First name cannot be empty")]
        public string first_name { get; set; }
        [Required(ErrorMessage = "Last name cannot be empty")]
        public string last_name { get; set; }
        [Required(ErrorMessage = "E-mail cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        [DataType(DataType.Password)]
        //public string password { get { return Decrypt(password); } set { Encrypt(password); } }
        public string password { get; set; }
        [Required(ErrorMessage = "Re-type password cannot be empty")]
        [Compare("password", ErrorMessage = "Passwords do not match.")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string confirm_password { get; set; }
        [Required]
        [DefaultValue("Requested")]
        public string status { get; set; }
        public DateTime last_login { get; set; }
        [ForeignKey("group_id")]
        public tGroup group { get; set; }
        public string create_by { get; set; }
        public DateTime create_date { get; set; }
        public string edit_by { get; set; }
        public DateTime edit_date { get; set; }
        [NotMapped]
        public string full_name { get { return string.Format("{0} {1}", first_name, last_name); } }

        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "ENcRyPTBOLT!1234";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
        public string Encrypt(string clearText)
        {
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(clearText);

                byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
                var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
                var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

                byte[] cipherTextBytes;

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        cipherTextBytes = memoryStream.ToArray();
                        cryptoStream.Close();
                    }
                    memoryStream.Close();
                }
                return Convert.ToBase64String(cipherTextBytes);
            }
        }

        public string Decrypt(string cipherText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
    }
}
