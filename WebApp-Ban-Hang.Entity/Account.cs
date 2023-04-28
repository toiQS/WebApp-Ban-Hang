using System.ComponentModel.DataAnnotations;
namespace WebApp_Ban_Hang.Entity
{
    public class Account
    {
        [Key]
        [Required, MaxLength(20)]
        public string UserName { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
        public DateTime Create_At { get; set; }
        public DateTime Modifiled_At { get; set; }
        public DateTime Delete_At { get; set; }
    }
}
