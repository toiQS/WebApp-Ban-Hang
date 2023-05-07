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
        [HttpGet]
        public IActionResult Detail(int id)
        {
            //var userDetail =  _services.FindById(id);
            //if(userDetail == null)
            //    return NotFound();
            //var model = new Details
            //{
            //    UserDetailId = userDetail.
            //};
            return View();
        }
    }
}
