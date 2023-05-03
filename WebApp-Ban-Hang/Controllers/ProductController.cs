using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Models.Products;
using WebApp_Ban_Hang.Services.Products;

namespace WebApp_Ban_Hang.Controllers
{
    public class ProductController : Controller
    {
        private IProductServices productServices;
        private IWebHostEnvironment webHostEnvironment;
        public ProductController(IProductServices productServices, IWebHostEnvironment webHostEnvironment)
        {
            this.productServices = productServices;
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = productServices.ViewAll().Select(product => new Indexs
            {
                
            });
            return View(model);
        }
        
    }
}
