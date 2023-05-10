using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.Brands
{
    public class Creates
    {
        [Key, Required, MaxLength(10)]
<<<<<<< Updated upstream
        [Display(Name = "ID Thương Hiệu")] 
=======

        [Display(Name = "ID Thương Hiệu")]
>>>>>>> Stashed changes
        public string BrandId { get; set; }
        
        [Required, MaxLength(20)]
<<<<<<< Updated upstream
        [Display(Name = "Tên Thương Hiệu")] 
=======

        [Display(Name = "Tên Thương Hiệu")]
>>>>>>> Stashed changes
        public string BrandName { get; set; }
    }
}
