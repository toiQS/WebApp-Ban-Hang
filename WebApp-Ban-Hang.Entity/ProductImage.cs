using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Ban_Hang.Entity
{
    public class ProductImage
    {
        [Key,Required, MaxLength (11)]
        public int ImageID { get; set; }
        [ForeignKey("Product"),Required, MaxLength (50)]
        public string ProductLine { get; set; }
        public Product? Product { get; set; }
        [Required, MaxLength (50)]
        public string ImageURL { get; set; }
    }
}
