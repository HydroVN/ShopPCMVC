using System;
using System.ComponentModel.DataAnnotations;

namespace MVCQuanLyBanMayTinh.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Mật khẩu hệ thống không được để trống.")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Họ và tên không được để trống.")]
        public string FullName { get; set; } = null!;

        public int Role_Id { get; set; } = 2; // Khóa ngoại kết nối sang bảng Roles (1: Admin, 2: Client)

        public DateTime? Created_At { get; set; }

        public virtual Role? Role { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tài khoản.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}