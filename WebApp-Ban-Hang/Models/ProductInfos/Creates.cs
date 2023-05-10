using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.ProductInfos
{
    public class Creates
    {
        [Key, Required, MaxLength(10)]
<<<<<<< Updated upstream
        [Display(Name = "ID Thông Tin Sản Phẩm")]
        public int Info_ID { get; set; }
        [Display(Name = "Dòng Sản Phẩm")]
        public string Product_Line { get; set; }
=======

        [Display(Name = "ID Thông Tin Sản Phẩm")]
        public int Info_ID { get; set; }

        [Display(Name = "Dòng Sản Phẩm")]
        public string Product_Line { get; set; }

>>>>>>> Stashed changes
        [Display(Name = "Thông Tin Sản Phẩm")]
        public string Product_Infomation { get; set; }
    }
}
