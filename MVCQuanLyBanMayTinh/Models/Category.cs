using MVCQuanLyBanMayTinh.Models;
using System;
using System.Collections.Generic;

namespace MVCQuanLyBanMayTinh.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Created_At { get; set; }

        // Đồng bộ gọi lớp Computer chung một Namespace để xóa bỏ hoàn toàn lỗi CS0246
        public virtual ICollection<Computer> Computers { get; set; } = new List<Computer>();
    }
}