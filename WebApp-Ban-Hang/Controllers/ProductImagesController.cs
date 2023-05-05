using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.IIS.Core;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Models.ProductImages;
using WebApp_Ban_Hang.Services.ProductImages;

namespace WebApp_Ban_Hang.Controllers
{
    public class ProductImagesController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private IProductImageServices imageServices;
        public ProductImagesController(IWebHostEnvironment webHostEnvironment, IProductImageServices imageServices)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.imageServices = imageServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = imageServices.ViewAll().Select(images => new Indexs
            {
                ProductLine = images.ProductLine,
                ImageURL = images.ImageURL,
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
        public async Task <IActionResult> Create(Creates model)
        {
            if (ModelState.IsValid)
            {
                var image = new ProductImage
                {
                    ImageID = model.ImageID,
                    ProductLine = model.ProductLine,
                };
                if (model.ImageURL != null && model.ImageURL.Length > 0)
                {
                    var uploadDir = @"images/ProductImages";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageURL.FileName);
                    var extension = Path.GetExtension(model.ImageURL.FileName);
                    var webRootPath = webHostEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yyyymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageURL.CopyToAsync(new FileStream(path, FileMode.Create));
                    image.ImageURL = "/" + uploadDir + "/" + fileName;
                    await imageServices.CreateAsSync(image);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var image = imageServices.FindById(id);
            if(image == null)
            {
                return NotFound();
            }
            var model = new Details
            {
                ImageID = image.ImageID,
                ProductLine = image.ProductLine,
                ImageURL = image.ImageURL,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var image = imageServices.FindById(id);
            if(image == null)
            {
                return NotFound();
            }
            var model = new Edits
            {
                ImageID = image.ImageID,
                ProductLine = image.ProductLine,
                ImageURL = image.ImageURL,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits model)
        {
            var images = imageServices.FindById(model.ImageID);
            if(images == null)
            {
                return NotFound();
            }
            images.ImageID = model.ImageID;
            images.ProductLine = model.ProductLine;
            images.ImageURL = model.ImageURL;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var images = imageServices.FindById(id);
            if (images == null)
            {
                return NotFound();
            }
            var model = new Deletes
            {
                ImageID = images.ImageID,
                ImageURL = images.ImageURL,
                ProductLine = images.ProductLine,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if(ModelState.IsValid)
            {
                await imageServices.DeleteById(model.ImageID);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
