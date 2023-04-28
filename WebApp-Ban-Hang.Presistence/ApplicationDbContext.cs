using Microsoft.EntityFrameworkCore;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Presistence
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }
        public DbSet<ProductWarranty> ProductWarranty { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<UserOrder> UserOrder { get; set; }
    }
}
