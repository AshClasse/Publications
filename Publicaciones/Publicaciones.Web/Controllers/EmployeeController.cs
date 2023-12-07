using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Web.ViewModels.ControllerService;
using Publicaciones.Web.ViewModels.Models.EmpViewModels;
using Publicaciones.Web.Responses.Core;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Publicaciones.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly string URL;
        private readonly IEmployeeService _employeeService;
        private readonly HttpClientHandler _httpClientHandler;
        private readonly IWebService _webservice;

        public EmployeeController(IEmployeeService employeeService,
                                   IConfiguration configuration,
                                   IWebService webService)
        {
            _employeeService = employeeService;
            _httpClientHandler = new HttpClientHandler();
            URL = configuration["BaseURL:BaseEmpURL"];
            _webservice = webService;
        }

        public ActionResult Index()
        {
            try
            {

                BaseResponse<List<GetEmpViewModel>> result = _webservice.GetData<List<GetEmpViewModel>>($"{URL}GetEmployees");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int ID)
        {
            try
            {
                BaseResponse<GetEmpViewModel>
                result = _webservice.GetData<GetEmpViewModel>($"{URL}GetEmployeesByID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpDefaultViewModel addmodel)
        {
            addmodel.ChangeDate = DateTime.Now;
            addmodel.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<EmpDefaultViewModel>>($"{URL}SaveEmployee", addmodel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }


        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int ID)
        {
            try
            {
                BaseResponse<EmpDefaultViewModel>
                result = _webservice.GetData<EmpDefaultViewModel>($"{URL}GetEmployeesByID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpDefaultViewModel updatemodel)
        {
            updatemodel.ChangeDate = DateTime.Now;
            updatemodel.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<EmpDefaultViewModel>>($"{URL}UpdateEmployees", updatemodel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int ID)
        {
            try
            {
                BaseResponse<EmpDeleteViewModel> result = _webservice.GetData<EmpDeleteViewModel>($"{URL}GetEmployeesByID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID, EmpDeleteViewModel deletemodel)
        {
            deletemodel.EmpID = ID;
            deletemodel.ChangeDate = DateTime.Now;
            deletemodel.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<EmpDefaultViewModel>>($"{URL}DeleteEmployees", deletemodel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

    }
}
