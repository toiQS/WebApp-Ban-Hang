using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Models.Order;
using WebApp_Ban_Hang.Services.Orders;
using WebApp_Ban_Hang.Services.Products;

namespace WebApp_Ban_Hang.Controllers
{
    public class OrderController : Controller
    {
        private IOrderServices _service;
        private IWebHostEnvironment _webHostEnvironment;
        public OrderController(IOrderServices service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _service.ViewAll().Select(order => new Indexs
            {
                IdOrder = order.IdOrder,
                IdProduct= order.IdProduct,
                IdUser= order.IdUser,
                TextNote= order.TextNote,
                Total = order.Total
            });
            return View(model);
        }
        [HttpGet]
        public IActionResult Create() {
            var model = new Creates();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Creates model)
        {
            if (ModelState.IsValid) {
                var order = new Order
                {
                    IdOrder = model.IdOrder,
                    IdProduct = model.IdProduct,
                    IdUser = model.IdUser,
                    TextNote = model.TextNote,
                    Total = model.Total
                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id) {
            var order = _service.FindById(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = new Details
            {
                IdOrder = order.IdOrder,
                IdProduct = order.IdProduct,
                IdUser = order.IdUser,
                TextNote = order.TextNote,
                Total = order.Total
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var order = _service.FindById(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = new Edits
            {
                IdOrder = order.IdOrder,
                IdProduct = order.IdProduct,
                IdUser = order.IdUser,
                TextNote = order.TextNote,
                Total = order.Total
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits model)
        {
            var order = _service.FindById(model.IdOrder);
            if (order == null)
            {
                return NotFound();
            }
            order.IdUser = model.IdUser;
            order.IdProduct = model.IdProduct;
            order.IdUser = model.IdUser;
            order.TextNote = model.TextNote;
            order.Total = model.Total;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var order= _service.FindById(id);
            if (order == null)
            {
                return NotFound();
            }
            var model = new Deletes
            {
                IdOrder = order.IdOrder,
                IdProduct = order.IdProduct,
                IdUser = order.IdUser,
                TextNote = order.TextNote,
                Total = order.Total
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if(ModelState.IsValid)
            {
                await _service.DeleteAsSync(model.IdOrder);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Sort(string sortOrder, string searchString)
        {
            ViewData["IdOrderSortParm"] = sortOrder == "IdOrder" ? "IdOrder_desc" : "IdOrder";
            ViewData["IdProductSortParm"] = sortOrder == "IdProduct" ? "ProductLine_desc" : "IdProduct";
            ViewData["IdUserSortParm"] = sortOrder == "IdUser" ? "IdUser_desc" : "IdUser";
            ViewData["TotalSortParm"] = sortOrder == "Total" ? "Total_desc" : "Total";
            ViewData["CurrentFilter"] = searchString;
            var Product = _service.ViewAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                Product = Product.Where(s => s.IdOrder.ToString().Contains(searchString)
                                       || s.IdProduct.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Total":
                    Product = Product.OrderBy(s => s.Total);
                    break;
                case "Total_desc":
                    Product = Product.OrderByDescending(s => s.Total);
                    break;
                case "IdUser":
                    Product = Product.OrderBy(s => s.IdUser);
                    break;
                case "IdUser_desc":
                    Product = Product.OrderByDescending(s => s.IdUser);
                    break;
                case "IdOrder":
                    Product = Product.OrderBy(s => s.IdOrder);
                    break;
                case "IdOrder_desc":
                    Product = Product.OrderByDescending(s => s.IdOrder);
                    break;
                case "IdProduct":
                    Product = Product.OrderBy(s => s.IdProduct);
                    break;
                case "ProductLine_desc":
                    Product = Product.OrderByDescending(s => s.IdProduct);
                    break;
                default:
                    Product = Product.OrderBy(s => s.IdOrder);
                    break;
            }
            return View(Product);
        }
    }
}
