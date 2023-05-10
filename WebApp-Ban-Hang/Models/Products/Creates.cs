using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.Products
{
    public class Creates
    {
        [Key, Required(ErrorMessage ="Product Line is required"), MaxLength(50)]
        [Display(Name = "Dòng Sản Phẩm")]
        public string Product_Line { get; set; }
        [Required, MaxLength(150)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Product_Name { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "Hình Ảnh")]
        public string Thumbnail { get; set; }
        [Required, MaxLength(10)]
        [Display(Name = "Giá")]
        public int Price { get; set; }
        [Required, MaxLength(3)]
        [Display(Name = "Giảm Giá")]
        public uint Discount { get; set; }
        public DateTime Create_At { get; set; } = DateTime.Now;
        public DateTime Modified_At { get; set; } = DateTime.Now;
        public DateTime Delete_At { get; set; } = DateTime.Now;
        //public string Create_By { get; set; }
        [Display(Name = "ID Thương Hiệu")]
        public string BrandId { get; set; }
        [Display(Name = "ID Loại")]
        public int CategoryID { get; set; }
    }
}
