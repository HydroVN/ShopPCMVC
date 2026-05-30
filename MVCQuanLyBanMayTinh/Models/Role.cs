using MVCQuanLyBanMayTinh.Models;
using System;
using System.Collections.Generic;

namespace MVCQuanLyBanMayTinh.Models
{
    public class Role
    {
        public int Id { get; set; } // 1: Admin, 2: Client
        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}