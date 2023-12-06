using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Publicaciones.Web.Controllers
{
    public class TitleAuthorWithHttpClientController : Controller
    {
        // GET: TitleAuthorWithHttpClientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TitleAuthorWithHttpClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TitleAuthorWithHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitleAuthorWithHttpClientController/Create
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

        // GET: TitleAuthorWithHttpClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TitleAuthorWithHttpClientController/Edit/5
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

        // GET: TitleAuthorWithHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TitleAuthorWithHttpClientController/Delete/5
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
