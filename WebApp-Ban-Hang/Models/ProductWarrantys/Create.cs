using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.ProductWarrantys
{
    public class Create
    {
        [Key, Required, MaxLength(50)]
        public string Product_ID { get; set; }
        public DateTime Purchased_At { get; set; }
        public DateTime Warranty_Period { get; set; }
        public string Product_Line { get; set; }
    }
}
