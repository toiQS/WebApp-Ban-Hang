using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.ProductInfos
{
    public class Creates
    {
        [Key, Required, MaxLength(10)]
        public int Info_ID { get; set; }
        public string Product_Line { get; set; }
        public string Product_Infomation { get; set; }
    }
}
