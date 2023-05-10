namespace WebApp_Ban_Hang.Models.User
{
    public class CreateUser
    {
        [Required(ErrorMessage = "User Name tài khoản là bắt buộc")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email tài khoản là bắt buộc")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng email")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [DisplayName("Mật Khẩu")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{8,20}$", ErrorMessage = "Mật khẩu ít nhất 8 kí tự, phải có 1 kí tự đặc biệt, chữ số và kí tự viết hoa")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Mật khẩu xác nhận là bắt buộc")]
        [DisplayName("Xác Nhận Mật Khẩu")]
        [DataType(DataType.Password)]

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không trùng khớp")]
        public string ConfirmPassword { get; set; }
    }
}
