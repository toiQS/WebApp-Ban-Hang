using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.ProductWarrantys
{
    public class Creates
    {
        [Key, Required, MaxLength(50)]
        [Display(Name = "ID Sản Phẩm")]
        public string Product_ID { get; set; }
        public DateTime Purchased_At { get; set; }
        public DateTime Warranty_Period { get; set; }
        [Display(Name = "Dòng Sản Phẩm")]
        public string Product_Line { get; set; }
    }
}
