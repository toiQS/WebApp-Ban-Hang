using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.Categorys
{
    public class Creates
    {
        [Key, Required, MaxLength(10)]
        [Display(Name = "ID Loại")]
        public int CategoryID { get; set; }
        [Required, MaxLength(50)]
        [Display(Name = "Tên Loại")]
        public string CategoryName { get; set; }
    }
}
