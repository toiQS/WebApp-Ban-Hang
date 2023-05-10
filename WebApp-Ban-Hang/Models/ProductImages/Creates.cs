using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.ProductImages
{
    public class Creates
    {
        [Key, Required, MaxLength(11)]
        [Display(Name = "ID Hình Ảnh")]
        public int ImageID { get; set; }
        [Display(Name = "Dòng Sản Phẩm")]
        public string ProductLine { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "URL Hình Ảnh")]
        public IFormFile ImageURL { get; set; }
    }
}