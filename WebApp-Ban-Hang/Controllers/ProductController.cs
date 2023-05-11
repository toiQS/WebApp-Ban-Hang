using Microsoft.AspNetCore.Mvc;
using System.Drawing;
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
                 
                    Price= model.Price,
                    Discount= model.Discount,
                    Create_At = model.Create_At,
                    Modified_At = model.Modified_At,
                    Delete_At = model.Delete_At,
                    BrandId = model.BrandId,
                    CategoryID = model.CategoryID,
                };
                if (model.Thumbnail != null && model.Thumbnail.Length > 0)
                {
                    var uploadDir = @"images/Products";
                    var fileName = Path.GetFileNameWithoutExtension(model.Thumbnail.FileName);
                    var extension = Path.GetExtension(model.Thumbnail.FileName);
                    var webRootPath = webHostEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yyyymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.Thumbnail.CopyToAsync(new FileStream(path, FileMode.Create));
                    product.Thumbnail = "/" + uploadDir + "/" + fileName;
                    await productServices.CreateAsSync(product);
                    return RedirectToAction("index");
                }
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
                BrandId = product.BrandId,
                CategoryID = product.CategoryID,
            };
            return View(model);
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
            return View();
        }
        public async Task<IActionResult> Sort(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["ProductNameSortParm"] = sortOrder == "ProductName" ? "ProductName_desc" : "ProductName";
            ViewData["ProductLineSortParm"] = sortOrder == "ProductLine" ? "ProductLine_desc" : "ProductLine";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "Price_desc" : "Price";
            ViewData["DiscountSortParm"] = sortOrder == "Discount" ? "Discount_desc" : "Discount";
            ViewData["Create_AtSortParm"] = sortOrder == "Create_At" ? "Create_At_desc" : "Create_At";
            ViewData["Modified_AtSortParm"] = sortOrder == "Modified_At" ? "Modified_At_desc" : "Modified_At";
            ViewData["Delete_AtSortParm"] = sortOrder == "Delete_At" ? "Delete_At_desc" : "Delete_At";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var Product = productServices.ViewAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                Product = Product.Where(s => s.Product_Name.Contains(searchString)
                                       || s.Product_Line.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Create_At":
                    Product = Product.OrderBy(s => s.Create_At);
                    break;
                case "Create_At_desc":
                    Product = Product.OrderByDescending(s => s.Create_At);
                    break;
                case "Modified_At":
                    Product = Product.OrderBy(s => s.Modified_At);
                    break;
                case "Modified_At_desc":
                    Product = Product.OrderByDescending(s => s.Modified_At);
                    break;
                case "Delete_At":
                    Product = Product.OrderBy(s => s.Delete_At);
                    break;
                case "Delete_At_desc":
                    Product = Product.OrderByDescending(s => s.Delete_At);
                    break;
                case "Discount":
                    Product = Product.OrderBy(s => s.Discount);
                    break;
                case "Discount_desc":
                    Product = Product.OrderByDescending(s => s.Discount);
                    break;
                case "Price":
                    Product = Product.OrderBy(s => s.Price);
                    break;
                case "Price_desc":
                    Product = Product.OrderByDescending(s => s.Price);
                    break;
                case "ProductName":
                    Product = Product.OrderBy(s => s.Product_Name);
                    break;
                case "ProductName_desc":
                    Product = Product.OrderByDescending(s => s.Product_Name);
                    break;
                case "ProductLine":
                    Product = Product.OrderBy(s => s.Product_Line);
                    break;
                case "ProductLine_desc":
                    Product = Product.OrderByDescending(s => s.Product_Line);
                    break;
                default:
                    Product = Product.OrderBy(s => s.Product_Line);
                    break;
            }
            int pageSize = 8;
            return View(await PaginatedList<Product>.CreateAsync((IQueryable<Product>)Product, pageNumber ?? 1, pageSize));
        }
    }
}
