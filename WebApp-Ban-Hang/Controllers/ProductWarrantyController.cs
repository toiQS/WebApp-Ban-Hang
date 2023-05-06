using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(warranty => new Indexs()
            {
                Product_Line = warranty.Product_Line,
                Purchased_At = warranty.Purchased_At,
                Warranty_Period = warranty.Warranty_Period
            });
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
            return View(model);
        }
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
            return View(model);
        }
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
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var warranty = _services.FindById(id);
            if(warranty == null)
                return NotFound();
            var model = new Deletes
            {
                Product_ID = id,
                Product_Line = warranty.Product_Line,
                Purchased_At = warranty.Purchased_At,
                Warranty_Period = warranty.Warranty_Period
            };
            return View(model);
        }
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
    }
}
