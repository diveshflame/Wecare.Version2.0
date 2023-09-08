using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wecare.Api.Controllers
{
    public class ViewAppointmentController : Controller
    {
        // GET: ViewAppointmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ViewAppointmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewAppointmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewAppointmentController/Create
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

        // GET: ViewAppointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ViewAppointmentController/Edit/5
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

        // GET: ViewAppointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ViewAppointmentController/Delete/5
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
