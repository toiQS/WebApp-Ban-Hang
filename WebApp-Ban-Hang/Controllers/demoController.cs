using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_Ban_Hang.Controllers
{
    public class demoController : Controller
    {
        // GET: demoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: demoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: demoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: demoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: demoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: demoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: demoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: demoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
