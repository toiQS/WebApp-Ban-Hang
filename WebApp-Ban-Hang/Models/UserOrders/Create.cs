using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Models.UserOrders
{
    public class Create
    {
        [Key, Required, MaxLength(11)]
        public int OrderID { get; set; }
        public string UserName { get; set; }
        public DateTime Create_At { get; set; }
        [Required, MaxLength(20)]
        public string Status { get; set; }
        [Required, MaxLength(10)]
        public uint Total { get; set; }
        public string Comfirmed_by { get; set; }
    }
}
