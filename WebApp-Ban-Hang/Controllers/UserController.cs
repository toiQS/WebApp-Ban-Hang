using Microsoft.AspNetCore.Mvc;
using WebApp_Ban_Hang.Services.Users;
using WebApp_Ban_Hang.Models.User;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using WebApp_Ban_Hang.Entity;

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
        // GET: /User/
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
            return Json(model);
        }
        // GET: /User/Detail/5
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
            return Json(model);
        }
        // GET: /User/Create
        [HttpGet]
        public IActionResult Create()
        {
            var model = new Creates();
            return Json(model);
        }
        // POST: /User/Create
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
        // GET: /User/Edit/1
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
            return Json(model);
        }
        // POST: /User/Edit/1
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
        // GET: /User/Delete/2
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
            return Json(model);
        }
        // POST: /User/Delete/2
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
        public async Task<IActionResult> Sort(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["IdUserSortParm"] = sortOrder == "IdUser" ? "IdUser_desc" : "IdUser";
            ViewData["FirstNameSortParm"] = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
            ViewData["MiddleNameSortParm"] = sortOrder == "MiddleName" ? "MiddleName_desc" : "MiddleName";
            ViewData["LastNameSortParm"] = sortOrder == "LastName" ? "LastName_desc" : "LastName";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var user = _services.ViewAll();
            if (!String.IsNullOrEmpty(searchString))
            {
                user = user.Where(s => s.IdUser.ToString().Contains(searchString)
                                       || s.FullName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "LastName":
                    user = user.OrderBy(s => s.LastName);
                    break;
                case "LastName_desc":
                    user = user.OrderByDescending(s => s.LastName);
                    break;
                case "MiddleName":
                    user = user.OrderBy(s => s.MiddleName);
                    break;
                case "MiddleName_desc":
                    user = user.OrderByDescending(s => s.MiddleName);
                    break;
                case "IdUser":
                    user = user.OrderBy(s => s.IdUser);
                    break;
                case "IdUser_desc":
                    user = user.OrderByDescending(s => s.IdUser);
                    break;
                case "FirstName":
                    user = user.OrderBy(s => s.FirstName);
                    break;
                case "FirstName_desc":
                    user = user.OrderByDescending(s => s.FirstName);
                    break;
                default:
                    user = user.OrderBy(s => s.IdUser);
                    break;
            }
            int pageSize = 5;
            return View(await PaginatedList<ProductWarranty>.CreateAsync((IQueryable<ProductWarranty>)user, pageNumber ?? 1, pageSize));
        }
    }
}
