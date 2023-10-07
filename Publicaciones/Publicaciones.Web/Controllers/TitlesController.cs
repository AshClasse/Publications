using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Publicaciones.Domain.Repository;

namespace Publicaciones.Web.Controllers
{
    public class TitlesController : Controller
    {
        public TitlesController(ITitlesRepository titlesRepository) { }
        // GET: TitlesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TitlesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TitlesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitlesController/Create
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

        // GET: TitlesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TitlesController/Edit/5
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

        // GET: TitlesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TitlesController/Delete/5
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
