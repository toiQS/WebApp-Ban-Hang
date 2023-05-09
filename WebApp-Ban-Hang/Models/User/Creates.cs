using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace WebApp_Ban_Hang.Models.User
{
    public class Creates
    {
        [Key]
        public int IdUser { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        public string? MiddleName { get;set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        //public string FullName
        //{
        //    get
        //    {
        //        return FirstName + (string.IsNullOrEmpty(MiddleName)) ? " ": (" "+ MiddleName+ " ")+ LastName;
        //    }
        //}
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
    }
}
