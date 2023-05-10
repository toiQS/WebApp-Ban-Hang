using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Services.Users;
using WebApp_Ban_Hang.Models.User;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;

namespace WebApp_Ban_Hang.Controllers
{
    public class UserController : Controller
    {
        private IUserServices _services;
        private IWebHostEnvironment _webHostEnvironment;
        public UserController(IUserServices services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(user => new Indexs
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                ImageUrl = user.ImageUrl,
            });
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = _services.FindById(id);
            if (user == null)
                return NotFound();
            var model = new Details
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                ImageUrl = user.ImageUrl,
                LastName = user.LastName,
                Mail = user.Mail,
                Address = user.Address,
                FullName = user.FullName,
                Phone = user.Phone,
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
            if (ModelState.IsValid)
            {
                var user = new Creates
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    ImageUrl = model.ImageUrl,
                    Address = model.Address,
                    IdUser = model.IdUser,
                    Mail = model.Mail,
                    Phone = model.Phone,
                };
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _services.FindById(id);
            if(user == null)
                return NotFound();
            var model = new Edits
            {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mail = user.Mail,
                MiddleName = user.MiddleName,
                Address = user.Address,
                ImageUrl = user.ImageUrl,
                Phone = user.Phone,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Edits model)
        {
            var user = _services.FindById(model.IdUser);
            if (user == null)
                return NotFound();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.MiddleName = model.MiddleName;
            user.Address = model.Address;
            user.ImageUrl = model.ImageUrl;
            user.Phone = model.Phone;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _services.FindById(id);
            if (user == null)
                return NotFound();
            var model = new Deletes
            {
                IdUser = user.IdUser,
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if (ModelState.IsValid)
            {
                _services.DeleteAsSync(model.IdUser);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
