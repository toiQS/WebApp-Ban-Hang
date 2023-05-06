using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Models.ProductInfos;
using WebApp_Ban_Hang.Services.ProductInfos;

namespace WebApp_Ban_Hang.Controllers
{
    public class ProductInfoController : Controller
    {
        private IProductInfoServices _services;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductInfoController(IProductInfoServices services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(info => new Indexs
            {
                Product_Line = info.ProductLine
            }) ;
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var info = _services.FindById(id);
            if(info == null)
                return NotFound();
            var model = new Details
            {
                Info_ID = info.Info_ID,
                Product_Line = info.Product_Line,
                Product_Infomation = info.Product_Infomation
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var info = new Creates();
            return View(info);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Creates info)
        {
            if(ModelState.IsValid)
            {
                var model = new ProductInfo
                {
                    Info_ID = info.Info_ID,
                    Product_Line = info.Product_Line,
                    Product_Infomation = info.Product_Infomation
                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var info = _services.FindById(id);
            if  (info == null)
                return NotFound();
            var model = new Edits
            {
                Info_ID = info.Info_ID,
                Product_Line = info.Product_Line,
                Product_Infomation = info.Product_Infomation
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits info)
        {
            var current = _services.FindById(info.Info_ID);
            if (current == null)
                return NotFound();
            info.Product_Line = current.Product_Line;
            info.Info_ID = current.Info_ID;
            info.Product_Infomation = current.Product_Infomation;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var info = _services.FindById(id);
            if(info == null)
                return NotFound();
            var model = new Deletes
            {
                Info_ID = info.Info_ID,
                Product_Line = info.Product_Line,
                Product_Infomation = info.Product_Infomation
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if (ModelState.IsValid)
            {
                await _services.DeleteById(model.Info_ID);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
