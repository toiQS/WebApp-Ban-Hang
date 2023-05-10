using System.ComponentModel.DataAnnotations;

namespace WebApp_Ban_Hang.Models.User
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Tên tài khoản là bắt buộc")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Lưu thông tin đăng nhập")]
        public bool RememberMe { get; set; }
    }
}
