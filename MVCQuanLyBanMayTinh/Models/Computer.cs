using System;
using System.ComponentModel.DataAnnotations;

namespace MVCQuanLyBanMayTinh.Models
{
    public class Computer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên máy tính không được bỏ trống.")]
        [StringLength(200)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Hãng sản xuất không được bỏ trống.")]
        public string Brand { get; set; } = null!;

        [Required(ErrorMessage = "Giá bán không được để trống.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Giá bán sản phẩm phải lớn hơn mức 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng nhập kho không được phép âm.")]
        public int Quantity { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Vui lòng lựa chọn phân loại danh mục máy tính.")]
        public int? Category_Id { get; set; }

        public DateTime? Created_At { get; set; }

        public virtual Category? Category { get; set; }

        public string Status => Quantity > 0 ? "Còn hàng" : "Hết hàng";
    }
}