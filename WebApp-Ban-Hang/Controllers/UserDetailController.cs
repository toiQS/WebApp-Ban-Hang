using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Models.UserDetails;
using WebApp_Ban_Hang.Services.UserDetails;

namespace WebApp_Ban_Hang.Controllers
{
    public class UserDetailController : Controller
    {
        private IUserDetailsServices _services;
        private IWebHostEnvironment _webHostEnvironment;
        public UserDetailController(IUserDetailsServices services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(_index => new Indexs
            {
                UserName = _index.UserName,
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
            if (ModelState.IsValid)
            {
                var userDetail = new Creates
                {
                    UserName = model.UserName,
                    UserDetailId = model.UserDetailId,
                    CityOrProvince = model.CityOrProvince,
                    DetaledAddress = model.DetaledAddress,
                    District = model.District,
                    Phone = model.Phone,
                    WardOrVillage = model.WardOrVillage
                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var userDetail = _services.FindById(id);
            if (userDetail == null)
                return NotFound();
            var model = new Details
            {
                UserDetailId = userDetail.UserDetailId,
                UserName = userDetail.UserName,
                CityOrProvince = userDetail.CityOrProvince,
                DetaledAddress = userDetail.DetaledAddress,
                District = userDetail.District,
                Phone = userDetail.Phone,
                WardOrVillage = userDetail.WardOrVillage,
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userDetail = _services.FindById(id);
            if(userDetail == null)
                return NotFound();
            var model = new Edits
            {
                UserName = userDetail.UserName,
                CityOrProvince = userDetail.CityOrProvince,
                DetaledAddress = userDetail.DetaledAddress,
                District = userDetail.District,
                Phone = userDetail.Phone,
                WardOrVillage = userDetail.WardOrVillage
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Edits model)
        {
            var userDetail = _services.FindById(model.UserDetailId);
            if (userDetail == null)
                return NotFound();
            userDetail.UserName = model.UserName;
            userDetail.CityOrProvince = model.CityOrProvince;
            userDetail.WardOrVillage = model.WardOrVillage;
            userDetail.DetaledAddress = model.DetaledAddress;
            userDetail.Phone = model.Phone;
            userDetail.District = model.District;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userDetail = _services.FindById(id);
            if(userDetail == null)  
                return NotFound();
            var model = new Deletes
            {
                CityOrProvince = userDetail.CityOrProvince,
                UserName = userDetail.UserName,
                UserDetailId = userDetail.UserDetailId,
                DetaledAddress = userDetail.DetaledAddress,
                District = userDetail.Phone,
                Phone = userDetail.District,
                WardOrVillage = userDetail.WardOrVillage
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if(ModelState.IsValid)
            {
                _services.DeleteById(model.UserDetailId);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
