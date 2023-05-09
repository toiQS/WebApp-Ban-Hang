using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_Ban_Hang.Entity
{
    public class Order
    {
        [Key]
        public int IdOrder { get; set; }
        [ForeignKey("Users")]
        public int IdUser { get; set; }
        public User? Users { get; set; }
        [ForeignKey("Order.Product")]
        public string IdProduct { get; set; }
        public Product? Product { get; set; }
        public string TextNote { get; set; }
        public uint Total { get; set; }
        
    }
}
