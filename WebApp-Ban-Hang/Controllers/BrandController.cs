using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Models.Brands;
using WebApp_Ban_Hang.Services.Brands;

namespace WebApp_Ban_Hang.Controllers
{
    public class BrandController : Controller
    {
        private IWebHostEnvironment env;
        private IBrandServices _services;
        public BrandController(IWebHostEnvironment env, IBrandServices services)
        {
            this.env = env;
            _services = services;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(brand => new Indexs
            {
                BrandName = brand.BrandName,

            });
            return Json(model);
        }
        [HttpGet]
        public IActionResult Detail(string id)
        {
            var brand = _services.FindById(id);
            if (brand == null)
                return NotFound();
            var model = new Details
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
            };
            return Json(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Creates();
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Creates model)
        {
            if(ModelState.IsValid)
            {
                var brand = new Creates
                {
                    BrandId = model.BrandId,
                    BrandName = model.BrandName,

                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var brand = _services.FindById(id);
            if(brand == null)
                return NotFound();
            var model = new Edits
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
            };
            return Json(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits model)
        {
            var brand = _services.FindById(model.BrandId);
            if(brand == null)
                return NotFound();
            brand.BrandId = model.BrandId;
            brand.BrandName = model.BrandName;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var brand = _services.FindById(id);
            if(brand == null)   
                return NotFound();
            var model = new Deletes
            {
                BrandId = brand.BrandId,
                
            };
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if (ModelState.IsValid)
            {
                _services.DeleteById(model.BrandId);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Sort(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["BrandNameSortParm"] = sortOrder == "BrandName" ? "BrandName" : "BrandName_desc";
            ViewData["BrandIdSortParm"] = sortOrder == "BrandId" ? "BrandId" : "BrandId_desc";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var brand = _services.ViewAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                brand = brand.Where(s => s.BrandName.Contains(searchString)
                                       || s.BrandId.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "BrandName":
                    brand = brand.OrderBy(s => s.BrandName);
                    break;
                case "BrandName_desc":
                    brand = brand.OrderByDescending(s => s.BrandName);
                    break;
                case "BrandId":
                    brand = brand.OrderBy(s => s.BrandId);
                    break;
                case "BrandId_desc":
                    brand = brand.OrderByDescending(s => s.BrandId);
                    break;
                default:
                    brand = brand.OrderBy(s => s.BrandName);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<Brand>.CreateAsync((IQueryable<Brand>)brand, pageNumber ?? 1, pageSize));
        }
    }
}
