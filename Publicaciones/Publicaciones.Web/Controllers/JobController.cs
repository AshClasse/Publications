using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;

namespace Publicaciones.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobsService _jobsService;

        public JobController(IJobsService jobService)
        {
            _jobsService = jobService;
        }
        // GET: JobController
        public ActionResult Index()
        {
            var result = _jobsService.GetAll();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: JobController/Details/5
        public ActionResult Details(int ID)
        {
            var result = _jobsService.GetByID(ID);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: JobController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobController/Create
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

        // GET: JobController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobController/Edit/5
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

        // GET: JobController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobController/Delete/5
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
