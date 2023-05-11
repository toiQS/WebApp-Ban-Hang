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
        private IProductServices _productServices;
        private IWebHostEnvironment _webHostEnvironment;
        public OrderController(IOrderServices service, IWebHostEnvironment webHostEnvironment, IProductServices productServices)
        {
            _productServices = productServices;
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: /Order/
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
            return Json(model);
        }
        // GET: /Order/Create
        [HttpGet]
        public IActionResult Create() {
            var model = new Creates();
            return Json(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Creates model)
        {
            uint total = (uint)_productServices.FindById(model.IdProduct).Price;
            if (ModelState.IsValid) {
                var order = new Order
                {
                    IdOrder = model.IdOrder,
                    IdProduct = model.IdProduct,
                    IdUser = model.IdUser,
                    TextNote = model.TextNote,
                    Total = total-(total*_productServices.FindById(model.IdProduct).Discount /100)
                };
            }
            return View();
        }
        // GET: /Order/Detail/2
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
            return Json(model);
        }
        // GET: /Order/Edit/1
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
            return Json(model);
        }
        // POST: /Order/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits model)
        {
            uint total = (uint)_productServices.FindById(model.IdProduct).Price;
            var order = _service.FindById(model.IdOrder);
            if (order == null)
            {
                return NotFound();
            }
            order.IdUser = model.IdUser;
            order.IdProduct = model.IdProduct;
            order.IdUser = model.IdUser;
            order.TextNote = model.TextNote;
            order.Total = total - (total * _productServices.FindById(model.IdProduct).Discount / 100);
            return View();
        }
        // GET: /Order/Delete/4
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
            };
            return Json(model);
        }
        // POST: /Order/Delete/4
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
        public async Task<IActionResult> Sort(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["IdOrderSortParm"] = sortOrder == "IdOrder" ? "IdOrder_desc" : "IdOrder";
            ViewData["IdProductSortParm"] = sortOrder == "IdProduct" ? "ProductLine_desc" : "IdProduct";
            ViewData["IdUserSortParm"] = sortOrder == "IdUser" ? "IdUser_desc" : "IdUser";
            ViewData["TotalSortParm"] = sortOrder == "Total" ? "Total_desc" : "Total";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var order = _service.ViewAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                order = order.Where(s => s.IdOrder.ToString().Contains(searchString)
                                       || s.IdProduct.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Total":
                    order = order.OrderBy(s => s.Total);
                    break;
                case "Total_desc":
                    order = order.OrderByDescending(s => s.Total);
                    break;
                case "IdUser":
                    order = order.OrderBy(s => s.IdUser);
                    break;
                case "IdUser_desc":
                    order = order.OrderByDescending(s => s.IdUser);
                    break;
                case "IdOrder":
                    order = order.OrderBy(s => s.IdOrder);
                    break;
                case "IdOrder_desc":
                    order = order.OrderByDescending(s => s.IdOrder);
                    break;
                case "IdProduct":
                    order = order.OrderBy(s => s.IdProduct);
                    break;
                case "ProductLine_desc":
                    order = order.OrderByDescending(s => s.IdProduct);
                    break;
                default:
                    order = order.OrderBy(s => s.IdOrder);
                    break;
            }
            int pageSize = 8;
            return View(await PaginatedList<Order>.CreateAsync((IQueryable<Order>)order, pageNumber ?? 1, pageSize));
        }
    }
}
