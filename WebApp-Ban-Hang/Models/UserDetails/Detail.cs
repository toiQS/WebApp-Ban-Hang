using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.UserDetails
{
    public class Detail
    {
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string? DetaledAddress { get; set; }
        public string WardOrVillage { get; set; }
        public string District { get; set; }
        public string CityOrProvince { get; set; }
        public string Phone { get; set; }
    }
}
