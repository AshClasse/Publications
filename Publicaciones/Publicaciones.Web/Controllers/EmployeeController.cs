using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Employee;

namespace Publicaciones.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
           var result = _employeeService.GetAll();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int ID)
        {
            var result = _employeeService.GetByID(ID);
            if (!result.Success)
            {
                ViewBag.Messag = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult(); 

            try
            {
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                result = _employeeService.Save(dtoadd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit()
        {
            EmployeeDtoUpdate dtoupdate = new EmployeeDtoUpdate();

            var result = _employeeService.Update(dtoupdate);
            if (!result.Success)
            {
                ViewBag.Messag = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // POST: EmployeeController/Edit/5
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
