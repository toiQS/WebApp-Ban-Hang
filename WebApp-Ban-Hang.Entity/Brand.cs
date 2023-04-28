using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Entity
{
    public class Brand
    {
        [Key,Required, MaxLength(10)]
        public string BrandId { get; set; }
        [Required, MaxLength(20)]
        public string BrandName { get; set;}
    }
}
