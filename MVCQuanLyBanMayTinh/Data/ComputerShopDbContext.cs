using Microsoft.EntityFrameworkCore;
using MVCQuanLyBanMayTinh.Models;

namespace MVCQuanLyBanMayTinh.Data
{
    public class ComputerShopDbContext : DbContext
    {
        public ComputerShopDbContext(DbContextOptions<ComputerShopDbContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Computer> Computers { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Sửa lỗi CS1662: Cấu hình Fluent API đồng bộ dữ liệu lớp thực thể
            modelBuilder.Entity<Computer>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Computers)
                .HasForeignKey(c => c.Category_Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.Role_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}