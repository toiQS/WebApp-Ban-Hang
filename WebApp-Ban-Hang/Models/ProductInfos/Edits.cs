using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.ProductInfos
{
    public class Edits
    {
        [Key, Required, MaxLength(10)]
        public int Info_ID { get; set; }
        public string Product_Line { get; set; }
        public string Product_Infomation { get; set; }
    }
}
