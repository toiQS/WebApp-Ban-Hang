using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Models.Categorys;
using WebApp_Ban_Hang.Services.Categorys;

namespace WebApp_Ban_Hang.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryServices _services;
        private IWebHostEnvironment _webHostEnvironment;
        public CategoryController(ICategoryServices services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(category => new Indexs
            {
                CategoryName = category.CategoryName
            });
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = _services.FindById(id);
            if(category == null) 
                return NotFound();
            var model = new Details
            {
                CategoryName = category.CategoryName,
                CategoryID = category.CategoryID
            };
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
                var category = new Creates
                {
                    CategoryID = model.CategoryID,
                    CategoryName = model.CategoryName
                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _services.FindById(id);
            if(category == null)
                return NotFound();
            var model = new Edits
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits model)
        {
            var category = _services.FindById(model.CategoryID);
            if(category == null)
                return NotFound();
            category.CategoryName = model.CategoryName;
            category.CategoryID = model.CategoryID;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _services.FindById(id);
            if (category == null)
                return NotFound();
            var model = new Deletes
            {
                CategoryID = category.CategoryID,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if (ModelState.IsValid)
            {
                _services.DeleteById(model.CategoryID);
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Sort(string sortOrder, string searchString)
        {
            ViewData["CategoryNameSortParm"] = sortOrder == "CategoryName" ? "CategoryName" : "CategoryName_desc";
            ViewData["CategoryIdSortParm"] = sortOrder == "CategoryId" ? "CategoryId" : "CategoryId_desc";
            ViewData["CurrentFilter"] = searchString;
            var Category = _services.ViewAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                Category = Category.Where(s => s.CategoryName.Contains(searchString)
                                       || s.CategoryID.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "CategoryName":
                    Category = Category.OrderBy(s => s.CategoryName);
                    break;
                case "CategoryName_desc":
                    Category = Category.OrderByDescending(s => s.CategoryName);
                    break;
                case "CategoryId":
                    Category = Category.OrderBy(s => s.CategoryID);
                    break;
                case "CategoryId_desc":
                    Category = Category.OrderByDescending(s => s.CategoryID);
                    break;
                default:
                    Category = Category.OrderBy(s => s.CategoryName);
                    break;
            }
            return View(Category);
        }
    }
}
