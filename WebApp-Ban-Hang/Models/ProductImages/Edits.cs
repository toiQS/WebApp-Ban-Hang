using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.ProductImages
{
    public class Edits
    {
        [Key, Required, MaxLength(11)]
        public int ImageID { get; set; }
        public string ProductLine { get; set; }
        [Required, MaxLength(50)]
        public string ImageURL { get; set; }
    }
}
