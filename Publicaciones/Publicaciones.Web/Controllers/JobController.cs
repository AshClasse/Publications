using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Jobs;
using Publicaciones.Web.Responses.Core;
using Publicaciones.Web.ViewModels.ControllerService;
using Publicaciones.Web.ViewModels.Models.EmpViewModels;
using Publicaciones.Web.ViewModels.Models.JobViewModels;

namespace Publicaciones.Web.Controllers
{
    public class JobController : Controller
    {
        public readonly string URL;
        private readonly IEmployeeService _employeeService;
        private readonly HttpClientHandler _httpClientHandler;
        private readonly IWebService _webservice;

        public JobController(IEmployeeService employeeService,
                                   IConfiguration configuration,
                                   IWebService webService)
        {
            _employeeService = employeeService;
            _httpClientHandler = new HttpClientHandler();
            URL = configuration["BaseURL:BaseJobURL"];
            _webservice = webService;
        }
        // GET: JobController
        public ActionResult Index()
        {
            try
            {
                BaseResponse<List<JobDefaultViewModel>> result = _webservice.GetData<List<JobDefaultViewModel>>($"{URL}GetJobs");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: JobController/Details/5
        public ActionResult Details(int ID)
        {
            try
            {
                BaseResponse<JobDefaultViewModel>
                result = _webservice.GetData<JobDefaultViewModel>($"{URL}GetJobsByID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: JobController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobDefaultViewModel dtoadd)
        {
            dtoadd.ChangeDate = DateTime.Now;
            dtoadd.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<JobDefaultViewModel>>($"{URL}SaveJobs", dtoadd);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: JobController/Edit/5
        public ActionResult Edit(int ID)
        {
            try
            {
                BaseResponse<JobDefaultViewModel>
                result = _webservice.GetData<JobDefaultViewModel>($"{URL}GetJobsByID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: JobController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ID , JobDefaultViewModel updatemodel)
        {
            updatemodel.JobID = ID;
            updatemodel.ChangeDate = DateTime.Now;
            updatemodel.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<JobDefaultViewModel>>($"{URL}UpdateJobs", updatemodel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: JobController/Delete/5
        public ActionResult Delete(int ID)
        {
            try
            {
                BaseResponse<JobDeleteViewModel> result = _webservice.GetData<JobDeleteViewModel>($"{URL}GetJobsByID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: JobController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID, JobDeleteViewModel detelemodel)
        {
            detelemodel.JobID = ID;
            detelemodel.ChangeDate = DateTime.Now;
            detelemodel.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<JobDeleteViewModel>>($"{URL}DeleteJobs", detelemodel);
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

