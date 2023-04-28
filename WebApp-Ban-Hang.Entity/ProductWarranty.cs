using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Ban_Hang.Entity
{
    public class ProductWarranty
    {
        [Key,Required, MaxLength(50)]
        public string Product_ID { get; set; }
        public DateTime Purchased_At { get; set; }
        public DateTime Warranty_Period { get; set; }
        [ForeignKey("Product"),Required, MaxLength(50)]
        public string Product_Line { get; set;}
        public Product? Product { get; set;}
    }
}
