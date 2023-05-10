namespace WebApp_Ban_Hang.Models.User
{
    public class Details
    {
        public int IdUser { get; set; }
        
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
       
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
    }
}
