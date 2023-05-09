using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp_Ban_Hang.Entity;

namespace WebApp_Ban_Hang.Presistence
{
    //public class ApplicationDbContext : DbContext
    //{
    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    //    public DbSet<Brand> Brand { get; set; }
    //    public DbSet<Category> Category { get; set; }
    //    public DbSet<Product> Product { get; set; }
    //    public DbSet<ProductImage> ProductImage { get; set; }
    //    public DbSet<ProductInfo> ProductInfo { get; set; }
    //    public DbSet<ProductWarranty> ProductWarranty { get; set; }
    //    public DbSet<User> User { get; set; }
    //    public DbSet<Order> Order { get; set; }
    //}
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }
        public DbSet<ProductWarranty> ProductWarranty { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "",
                    Name = "Admin",
                    NormalizedName = " Admin".ToUpper(),
                },
                new IdentityRole
                {
                    Id = "",
                    Name = "Manager",
                    NormalizedName = "Manager".ToUpper()
                });
            var hasher = new PasswordHasher<IdentityUser>();
            //builder.Entity<IdentityUser>().HasData
        }
    }
}
