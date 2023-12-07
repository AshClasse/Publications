using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Application.Service;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Pub_Info;
using Publicaciones.Web.Models.Responses.RoySched;

namespace Publicaciones.Web.Controllers
{
    public class RoySchedController : Controller
    {
        private readonly IRoySchedService _roySchedService;
        private readonly string roySchedApiURLBase;
        private readonly IApiService apiService;

        public RoySchedController(IRoySchedService roySchedService,IApiService apiService, IConfiguration configuration)
        {
            this._roySchedService = roySchedService;
            this.apiService = apiService;
            this.roySchedApiURLBase = configuration["ApiSettings:RoySchedApiBaseUrl"];
        }

        // GET: RoySchedController
        public ActionResult Index()
        {
            BaseResponse<List<RoySchedViewResult>> responseData = apiService.GetDataFromApi<List<RoySchedViewResult>>($"{roySchedApiURLBase}GetRoyScheds");

            if (responseData.success)
            {
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
        }

        // GET: RoySchedController/Details/5
        public ActionResult Details(int id)
        {

            BaseResponse<RoySchedViewResult> responseData = apiService.GetDataFromApi<RoySchedViewResult>($"{roySchedApiURLBase}GetRoySchedByID?ID={id}");

            if (responseData.success)
            {
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
        }

        // GET: RoySchedController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoySchedController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoySchedDtoAdd dtoAdd)
        {
            var apiUrl = $"{roySchedApiURLBase}SaveRoySched";

            dtoAdd.ChangeDate = DateTime.Now;
            dtoAdd.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<RoySchedAddResponse>(apiUrl, dtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: RoySchedController/Edit/5
        public ActionResult Edit(int id)
        {
            BaseResponse<RoySchedViewResult> responseData = apiService.GetDataFromApi<RoySchedViewResult>($"{roySchedApiURLBase}GetRoySchedByID?ID={id}");

            if (responseData.success)
            {
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
        }

        // POST: RoySchedController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoySchedDtoUpdate dtoUpdate)
        {
            var apiUrl = $"{roySchedApiURLBase}UpdateRoySched";

            dtoUpdate.ChangeDate = DateTime.Now;
            dtoUpdate.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<RoySchedUpdateResponse>(apiUrl, dtoUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Pub_InfoController/Delete/5
        public ActionResult Delete(int id)
        {
            BaseResponse<RoySchedDtoRemove> responseData = apiService.GetDataFromApi<RoySchedDtoRemove>($"{roySchedApiURLBase}GetRoySchedByID?ID={id}");

            if (responseData.success)
            {
                responseData.data.Id = id;
                responseData.data.ChangeUser = 1;
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoySchedDtoRemove dtoRemove)
        {
            var apiUrl = $"{roySchedApiURLBase}RemoveRoySched";

            dtoRemove.ChangeDate = DateTime.Now;
            dtoRemove.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<RoySchedDeleteResponse>(apiUrl, dtoRemove);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
