using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Web.Responses.Core;
using Publicaciones.Web.ViewModels.ControllerService;
using Publicaciones.Web.ViewModels.Models.PubViewModels;

namespace Publicaciones.Web.Controllers
{
    public class PublisherController : Controller
    {
        public readonly string URL;
        private readonly IEmployeeService _employeeService;
        private readonly HttpClientHandler _httpClientHandler;
        private readonly IWebService _webservice;

        public PublisherController(IEmployeeService employeeService,
                                   IConfiguration configuration,
                                   IWebService webService)
        {
            _employeeService = employeeService;
            _httpClientHandler = new HttpClientHandler();
            URL = configuration["BaseURL:BasePublisherURL"];
            _webservice = webService;
        }
        // GET: PublisherController
        public ActionResult Index()
        {
            try
            {
                BaseResponse<List<PubDefaultBaseModel>> result = _webservice.GetData<List<PubDefaultBaseModel>>($"{URL}GetPublishers");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int ID)
        {
            try
            {
                BaseResponse<PubDefaultBaseModel>
                result = _webservice.GetData<PubDefaultBaseModel>($"{URL}GetPublisherID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PubDefaultBaseModel dtoadd)
        {
            dtoadd.ChangeDate = DateTime.Now;
            dtoadd.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<PubDefaultBaseModel>>($"{URL}SavePublisher", dtoadd);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int ID)
        {
            try
            {
                BaseResponse<PubDefaultBaseModel>
                result = _webservice.GetData<PubDefaultBaseModel>($"{URL}GetPublisherID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( int ID, PubDefaultBaseModel updatemodel)
        {
            updatemodel.PubID = ID;
            updatemodel.ChangeDate = DateTime.Now;
            updatemodel.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<PubDefaultBaseModel>>($"{URL}UpdatePublisher", updatemodel);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int ID)
        {
            try
            {
                BaseResponse<PubDeleteViewModel> result = _webservice.GetData<PubDeleteViewModel>($"{URL}GetPublisherID?ID={ID}");
                return View(result.Data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: PublisherController/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost ]
        public ActionResult Delete(int ID, PubDeleteViewModel deletemodel)
        {
            deletemodel.PubID = ID;
            deletemodel.ChangeDate = DateTime.Now;
            deletemodel.ChangeUser = 1;

            try
            {
                _webservice.PostData<BaseResponse<PubDeleteViewModel>>($"{URL}DeletePublisher", deletemodel);
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
