using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.ProductImages
{
    public class Details
    {
        public int ImageID { get; set; }
        public string ProductLine { get; set; }
        public string ImageURL { get; set; }
    }
}
