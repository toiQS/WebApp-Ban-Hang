using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.UserOrders
{
    public class Detail
    {
        public int OrderID { get; set; }
        public string UserName { get; set; }
        public DateTime Create_At { get; set; }
        public string Status { get; set; }
        public uint Total { get; set; }
        public string Comfirmed_by { get; set; }
    }
}
