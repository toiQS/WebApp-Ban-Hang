using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace WebApp_Ban_Hang.Models.User
{
    public class Creates
    {
        [Key]
        [Display(Name = "ID Người Dùng")]
        public int IdUser { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        public string? MiddleName { get;set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + MiddleName + " "))+LastName;
            }
        }
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }
        public string Mail { get; set; }
        [Display(Name = "URL Hình Ảnh")]
        public string ImageUrl { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
    }
}
