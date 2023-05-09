using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.Products
{
    public class Creates
    {
        [Key, Required(ErrorMessage ="Product Line is required"), MaxLength(50)]
        public string Product_Line { get; set; }
        [Required, MaxLength(150)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$"), Display(Name = "Last Name")]
        public string Product_Name { get; set; }
        [Required, MaxLength(50)]
        public string Thumbnail { get; set; }
        [Required, MaxLength(10)]
        public int Price { get; set; }
        [Required, MaxLength(3)]
        public uint Discount { get; set; }
        public DateTime Create_At { get; set; } = DateTime.Now;
        public DateTime Modified_At { get; set; } = DateTime.Now;
        public DateTime Delete_At { get; set; } = DateTime.Now;
        //public string Create_By { get; set; }
        public string BrandId { get; set; }
        public int CategoryID { get; set; }
    }
}
