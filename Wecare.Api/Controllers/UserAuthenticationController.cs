using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wecare.Api.Controllers
{
    public class UserAuthenticationController : Controller
    {
        // GET: UserAuthenticationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserAuthenticationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserAuthenticationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserAuthenticationController/Create
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

        // GET: UserAuthenticationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserAuthenticationController/Edit/5
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

        // GET: UserAuthenticationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserAuthenticationController/Delete/5
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
