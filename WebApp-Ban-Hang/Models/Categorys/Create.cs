using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.Categorys
{
    public class Create
    {
        [Key, Required, MaxLength(10)]
        public int CategoryID { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }
    }
}
