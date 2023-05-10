using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp_Ban_Hang.Presistence;
using WebApp_Ban_Hang.Services.Brands;
using WebApp_Ban_Hang.Services.Categorys;
using WebApp_Ban_Hang.Services.Orders;
using WebApp_Ban_Hang.Services.ProductImages;
using WebApp_Ban_Hang.Services.ProductInfos;
using WebApp_Ban_Hang.Services.Products;
using WebApp_Ban_Hang.Services.ProductWarrantys;
using WebApp_Ban_Hang.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
// Add Services
builder.Services.AddScoped<IBrandServices, BrandServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IProductImageServices, ProductImageServices>();
builder.Services.AddScoped<IProductInfoServices, ProductInfoServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductWarrantyServices, ProductWarrantyServices>();
builder.Services.AddScoped<IUserServices, UserServices>();

//setting configure application cookie


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
