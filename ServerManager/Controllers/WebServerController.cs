using System.Web.Mvc;
using ServerManager.Models;

namespace ServerManager.Controllers
{
    public class WebServerController : Controller
    {
        // GET: WebServer
        public ActionResult Index()
        {
            return View();
        }

        // GET: WebServer/Details/5
        public ActionResult Details(string id)
        {
            return View(ServerRepository.Find(id));
        }

        // GET: WebServer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebServer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebServer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WebServer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebServer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WebServer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
