using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Models.ProductWarrantys;
using WebApp_Ban_Hang.Services.ProductWarrantys;

namespace WebApp_Ban_Hang.Controllers
{
    public class ProductWarrantyController : Controller
    {
        private IProductWarrantyServices _services;
        private IWebHostEnvironment _environment;
        public ProductWarrantyController(IProductWarrantyServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }
        // GET: /ProductWarranty/
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(warranty => new Indexs()
            {
                Product_Line = warranty.Product_Line,
                Purchased_At = warranty.Purchased_At,
                Warranty_Period = warranty.Warranty_Period
            });
            return Json(model);
        }
        // GET: /ProductWarranty/Create
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Creates();
            return Json(model);
        }
        // POST: /ProductWarranty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Creates model)
        {
            if(ModelState.IsValid)
            {
                var warranty = new ProductWarranty
                {
                    Product_ID = model.Product_ID,
                    Product_Line = model.Product_Line,
                    Purchased_At = model.Purchased_At,
                    Warranty_Period = model.Warranty_Period
                };
            }
            return View();
        }
        // GET: /ProductWarranty/Detail/2
        [HttpGet]
        public IActionResult Detail(string id)
        {
            var warranty = _services.FindById(id);
            if (warranty == null)
            {
                return NotFound();
            }
            var model = new Details
            {
                Product_ID = warranty.Product_ID,
                Product_Line = warranty.Product_Line,
                Purchased_At = warranty.Purchased_At,
                Warranty_Period = warranty.Warranty_Period
            };
            return Json(model);
        }
        // GET: /ProductWarranty/Edit/4
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var warrany = _services.FindById(id);
            if (warrany == null)
            {
                return NotFound();
            }
            var model = new Edits
            {
                Product_ID = warrany.Product_ID,
                Product_Line = warrany.Product_Line,
                Purchased_At = warrany.Purchased_At,
                Warranty_Period = warrany.Warranty_Period
            };
            return Json(model);
        }
        // POST: /ProductWarranty/Edit/4
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits model)
        {
           var warranty = _services.FindById(model.Product_ID);
            if (warranty == null)
            {
                return NotFound();
            }
            model.Product_Line = warranty.Product_Line;
            model.Product_ID    = warranty.Product_ID;
            model.Warranty_Period = warranty.Warranty_Period;
            model.Purchased_At = warranty.Purchased_At;
            return View();
        }
        // GET: /ProductWarranty/Delete/5
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var warranty = _services.FindById(id);
            if(warranty == null)
                return NotFound();
            var model = new Deletes
            {
                Product_ID = id,
            };
            return Json(model);
        }
        // POST: /ProductWarranty/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if (ModelState.IsValid)
            {
                await _services.DeleteById(model.Product_ID);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Sort(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["Product_IDSortParm"] = sortOrder == "Product_ID" ? "Product_ID_desc" : "Product_ID";
            ViewData["Purchased_AtSortParm"] = sortOrder == "Purchased_At" ? "Purchased_At_desc" : "Purchased_At";
            ViewData["Warranty_PeriodSortParm"] = sortOrder == "Warranty_Period" ? "Warranty_Period_desc" : "Warranty_Period";
            ViewData["Product_LineSortParm"] = sortOrder == "Product_Line" ? "Product_Line_desc" : "Product_Line";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var productWarranty = _services.ViewAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                productWarranty = productWarranty.Where(s => s.Product_ID.Contains(searchString)
                                       || s.Product_Line.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Product_Line":
                    productWarranty = productWarranty.OrderBy(s => s.Product_Line);
                    break;
                case "Product_Line_desc":
                    productWarranty = productWarranty.OrderByDescending(s => s.Product_Line);
                    break;
                case "Warranty_Period":
                    productWarranty = productWarranty.OrderBy(s => s.Warranty_Period);
                    break;
                case "Warranty_Period_desc":
                    productWarranty = productWarranty.OrderByDescending(s => s.Warranty_Period);
                    break;
                case "Product_ID":
                    productWarranty = productWarranty.OrderBy(s => s.Product_ID);
                    break;
                case "Product_ID_desc":
                    productWarranty = productWarranty.OrderByDescending(s => s.Product_ID);
                    break;
                case "Purchased_At":
                    productWarranty = productWarranty.OrderBy(s => s.Purchased_At);
                    break;
                case "Purchased_At_desc":
                    productWarranty = productWarranty.OrderByDescending(s => s.Purchased_At);
                    break;
                default:
                    productWarranty = productWarranty.OrderBy(s => s.Product_ID);
                    break;
            }
            int pageSize = 8;
            return View(await PaginatedList<ProductWarranty>.CreateAsync((IQueryable<ProductWarranty>)productWarranty, pageNumber ?? 1, pageSize));
        }
    }
}
