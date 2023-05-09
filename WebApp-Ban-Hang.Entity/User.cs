using System.ComponentModel.DataAnnotations;
namespace WebApp_Ban_Hang.Entity
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required,MaxLength(50)]
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required][MaxLength(50)]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
    }
}
