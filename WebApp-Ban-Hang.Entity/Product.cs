using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Ban_Hang.Entity
{
    public class Product
    {
        [Key,Required, MaxLength (50)]
        public string Product_Line { get; set; }
        [Required, MaxLength (150)]
        public string Product_Name { get; set;}
        [Required,MaxLength(50)]
        public string Thumbnail { get; set; }
        [Required, MaxLength(10)]
        public int Price { get; set;}
        [Required, MaxLength(3)]
        public uint Discount { get; set;}
        public DateTime Create_At { get; set; }
        public DateTime Modified_At { get; set; }
        public DateTime Delete_At { get; set; }
        [ForeignKey("Product.Account"),Required, MaxLength(20)]
        public string Create_By { get; set; }
        public Account? Account { get; set; }
        [ForeignKey("Brand"),Required, MaxLength(10)]
        public string BrandId { get; set; }
        public Brand? Brand { get; set; }
        [ForeignKey("Category"),Required, MaxLength(10)]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}
