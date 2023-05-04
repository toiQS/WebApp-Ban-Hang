using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Entity;
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
                Product_Name = product.Product_Name,
                Thumbnail = product.Thumbnail,
                Discount = product.Discount,
                Price = product.Price,
            }) ;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Creates();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Creates model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Product_Line = model.Product_Line,
                    Product_Name = model.Product_Name,
                    Thumbnail = model.Thumbnail,
                    Price= model.Price,
                    Discount= model.Discount,
                    Create_At = model.Create_At,
                    Modified_At = model.Modified_At,
                    Delete_At = model.Delete_At,
                    Create_By = model.Create_By,
                    BrandId = model.BrandId,
                    CategoryID = model.CategoryID,
                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            var product = productServices.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new Details
            {
                Product_Line = product.Product_Line,
                Product_Name = product.Product_Name,
                Thumbnail = product.Thumbnail,
                Price = product.Price,
                Discount = product.Discount,
                Create_At = product.Create_At,
                Modified_At = product.Modified_At,
                Delete_At = product.Delete_At,
                Create_By = product.Create_By,
                BrandId = product.BrandId,
                CategoryID = product.CategoryID,
            };
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var product = productServices.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new Edits
            {
                Product_Line = product.Product_Line,
                Product_Name = product.Product_Name,
                Thumbnail = product.Thumbnail,
                Price = product.Price,
                Discount = product.Discount,
                Create_At = product.Create_At,
                Modified_At = product.Modified_At,
                Delete_At = product.Delete_At,
                Create_By = product.Create_By,
                BrandId = product.BrandId,
                CategoryID = product.CategoryID,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Details model)
        {
            var product = productServices.FindById(model.Product_Line);
            if (product == null)
            {
                return NotFound();
            }
            product.Product_Line = model.Product_Line;
            product.Product_Name = model.Product_Name;
            product.Thumbnail = model.Thumbnail;
            product.Price = model.Price;
            product.Discount = model.Discount;
            product.BrandId = model.BrandId;
            product.CategoryID = model.CategoryID;
            return View();
        }
        [HttpGet]
        public IActionResult Detele(string id)
        {
            var product = productServices.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = new Deletes
            {
                Product_Line = product.Product_Line,
                Product_Name = product.Product_Name,
                Thumbnail = product.Thumbnail,
                Price = product.Price,
                Discount = product.Discount,
                BrandId = product.BrandId,
                CategoryID = product.CategoryID,
                Create_At = product.Create_At,
                Modified_At = product.Modified_At,
                Delete_At = product.Delete_At,
                Create_By = product.Create_By,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if(ModelState.IsValid)
            {
                await productServices.DeleteById(model.Product_Line);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
