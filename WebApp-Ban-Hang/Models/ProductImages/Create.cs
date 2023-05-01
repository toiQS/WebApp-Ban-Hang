using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.ProductImages
{
    public class Create
    {
        [Key, Required, MaxLength(11)]
        public int ImageID { get; set; }
        public string ProductLine { get; set; }
        [Required, MaxLength(50)]
        public IFormFile ImageURL { get; set; }
    }
}