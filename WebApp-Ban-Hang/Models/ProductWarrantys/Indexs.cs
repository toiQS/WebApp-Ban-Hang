using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.ProductWarrantys
{
    public class Indexs
    {
        
        
        public DateTime Purchased_At { get; set; }
        public DateTime Warranty_Period { get; set; }
        public string Product_Line { get; set; }
    }
}