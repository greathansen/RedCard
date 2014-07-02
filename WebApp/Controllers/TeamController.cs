using System.IO.Compression;
using System.Web.Mvc;
using WebApp.Daos;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult List()
        {
            var list = DataAccess<Team>.GetAll();
            return View(list);
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var team = new Team
                {
                    Name = collection.Get("Name")
                };
                DataAccess<Team>.Insert(team);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
        /*
        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
           return View();
        }

        // POST: Team/Edit/5
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

        // GET: Team/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Team/Delete/5
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
        }*/
    }
}
