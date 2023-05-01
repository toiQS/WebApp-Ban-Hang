using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.UserDetails
{
    public class Create
    {
        [Key, Required, MaxLength(11)]
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        [Required, MaxLength(30)]
        public string? DetaledAddress { get; set; }
        [Required, MaxLength(20)]
        public string WardOrVillage { get; set; }
        [Required, MaxLength(20)]
        public string District { get; set; }
        [Required, MaxLength(20)]
        public string CityOrProvince { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
    }
}
