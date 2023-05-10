using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.ProductWarrantys
{
    public class Creates
    {
        [Key, Required, MaxLength(50)]
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        [Display(Name = "ID Sản Phẩm")]
        public string Product_ID { get; set; }
        public DateTime Purchased_At { get; set; }
        public DateTime Warranty_Period { get; set; }
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        [Display(Name = "Dòng Sản Phẩm")]
        public string Product_Line { get; set; }
    }
}
