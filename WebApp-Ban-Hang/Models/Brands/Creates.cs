using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.Brands
{
    public class Creates
    {
        [Key, Required, MaxLength(10)]

        [Display(Name = "ID Thương Hiệu")]

        

        public string BrandId { get; set; }
        
        [Required, MaxLength(20)]

        [Display(Name = "Tên Thương Hiệu")] 

       

        public string BrandName { get; set; }
    }
}
