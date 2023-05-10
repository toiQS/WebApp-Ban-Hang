using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.Order
{
    public class Creates
    {
        [Key]
        public int IdOrder { get; set; }
        [ForeignKey("Users")]
        public int IdUser { get; set; }
        [ForeignKey("Order.Product")]
        public string IdProduct { get; set; }
        public string TextNote { get; set; }
        public uint Total { get; set; }
    }
}
