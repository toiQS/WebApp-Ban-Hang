using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Services.Products;

namespace WebApp_Ban_Hang.Controllers
{
    public class ProductController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
