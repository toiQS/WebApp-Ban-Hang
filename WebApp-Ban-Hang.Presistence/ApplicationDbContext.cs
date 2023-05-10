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
    //    public DbSet<ProductImage> Productimage { get; set; }
    //    public DbSet<ProductInfo> Productinfo { get; set; }
    //    public DbSet<ProductWarranty> Productwarranty { get; set; }
    //    public DbSet<User> User { get; set; }
    //    public DbSet<Order> Order { get; set; }
    }
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
    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    builder.Entity<IdentityUserRole<string>>().HasKey(x => new { x.RoleId, x.UserId });
    //    builder.Entity<IdentityRole>().HasData(
    //        new IdentityRole
    //        {
    //            Id = "admin-1",
    //            Name = "Admin",
    //            NormalizedName = " Admin".ToUpper(),
    //        },
    //        new IdentityRole
    //        {
    //            Id = "manager-1",
    //            Name = "Manager",
    //            NormalizedName = "Manager".ToUpper()
    //        });
    //    var hasher = new PasswordHasher<IdentityUser>();
    //    builder.Entity<IdentityUser>().HasData(
    //        new IdentityUser
    //        {
    //            Id = "super-admin-1",
    //            UserName = "Super Admin",
    //            NormalizedUserName = "SUPER ADMIN".ToUpper(),
    //            Email = "admin@gmail.com",
    //            NormalizedEmail = "ADMINGMAIL.COM".ToUpper(),
    //            PasswordHash = hasher.HashPassword(null, "Admin@123")
    //        });
    //    builder.Entity<IdentityUserRole<string>>().HasData(
    //        new IdentityUserRole<string>
    //        {
    //            UserId = "ff045d07-be86-4a4e-bfa4-0264ec832c12",
    //            RoleId = "88ac3925-8432-4f60-89e2-96433d08bbcf",
    //        });
    }
