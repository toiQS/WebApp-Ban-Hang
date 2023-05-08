﻿using Microsoft.AspNetCore.Mvc;
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
            return View(model);
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
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Creates();
            return View(model);
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
            return View(model);
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
                BrandName = brand.BrandName,
            };
            return View(model);
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
    }
}