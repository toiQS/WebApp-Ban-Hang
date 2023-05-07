using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApp_Ban_Hang.Entity;
using WebApp_Ban_Hang.Models.UserOrders;
using WebApp_Ban_Hang.Services.UserOrders;

namespace WebApp_Ban_Hang.Controllers
{
    public class UserOrderController : Controller
    {
        private IUserOrderServices _services;
        private IWebHostEnvironment _environment;
        public UserOrderController(IUserOrderServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _services.ViewAll().Select(order => new Indexs
            {
                Comfirmed_by = order.Comfirmed_by,
                Status = order.Status,
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
                var order = new UserOrder
                {
                    OrderID = model.OrderID,
                    UserName = model.UserName,
                    Create_At = model.Create_At,
                    Status = model.Status,
                    Total = model.Total,
                    Comfirmed_by = model.Comfirmed_by,
                };
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var order = _services.FindById(id);
            if (order == null)
                return NotFound();
            var model = new Details
            {
                OrderID = order.OrderID,
                UserName = order.UserName,
                Create_At = order.Create_At,
                Status = order.Status,
                Total = order.Total,
            };
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
                //OrderID =user.OrderID,
                UserName = user.UserName,
                Create_At = user.Create_At,
                Status = user.Status,
                Total = user.Total,
                Comfirmed_by = user.Comfirmed_by
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Edits model)
        {
            var order = _services.FindById(model.OrderID);
            if (order == null)
                return NotFound();
            order.UserName = model.UserName;
            order.Create_At = model.Create_At;
            order.Status = model.Status;
            order.Total = model.Total;
            order.Comfirmed_by = model.Comfirmed_by;
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var order = _services.FindById(id);
            if (order == null)
                return NotFound();
            var model = new Deletes
            {
                UserName = order.UserName,
                Create_At = order.Create_At,
                Status = order.Status,
                Total = order.Total,

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Deletes model)
        {
            if (ModelState.IsValid)
            {
                _services.DeleteAsSync(model.OrderID);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
