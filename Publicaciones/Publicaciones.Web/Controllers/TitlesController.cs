using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Application.Service;
using Publicaciones.Domain.Repository;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Pub_Info;
using Publicaciones.Web.Models.Responses.RoySched;
using Publicaciones.Web.Models.Responses.Titles;

namespace Publicaciones.Web.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitlesService _titlesService;
        private readonly string titlesApiURLBase;
        private readonly IApiService apiService;

        public TitlesController(ITitlesService titlesService, IApiService apiService, IConfiguration configuration)
        {
            this._titlesService = titlesService;
            this.apiService = apiService;
            this.titlesApiURLBase = configuration["ApiSettings:TitlesApiBaseUrl"];
        }

        // GET: TitlesController
        public ActionResult Index()
        {
            BaseResponse<List<TitlesViewResult>> responseData = apiService.GetDataFromApi<List<TitlesViewResult>>($"{titlesApiURLBase}GetTitles");

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

        // GET: TitlesController/Details/5
        public ActionResult Details(int id)
        {
            BaseResponse<TitlesViewResult> responseData = apiService.GetDataFromApi<TitlesViewResult>($"{titlesApiURLBase}GetTitleByID?ID={id}");

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

        // GET: TitlesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TitlesDtoAdd dtoAdd)
        {
            var apiUrl = $"{titlesApiURLBase}SaveTitle";

            dtoAdd.PubDate = DateTime.Now;
            dtoAdd.ChangeDate = DateTime.Now;
            dtoAdd.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<TitlesAddResponse>(apiUrl, dtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: TitlesController/Edit/5
        public ActionResult Edit(int id)
        {
            BaseResponse<TitlesViewResult> responseData = apiService.GetDataFromApi<TitlesViewResult>($"{titlesApiURLBase}GetTitleByID?ID={id}");

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

        // POST: TitlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TitlesDtoUpdate dtoUpdate)
        {
            var apiUrl = $"{titlesApiURLBase}UpdateTitle";

            dtoUpdate.ChangeDate = DateTime.Now;
            dtoUpdate.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<TitlesUpdateResponse>(apiUrl, dtoUpdate);

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
            BaseResponse<TitlesDtoRemove> responseData = apiService.GetDataFromApi<TitlesDtoRemove>($"{titlesApiURLBase}GetTitleByID?ID={id}");

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
        public ActionResult Delete(TitlesDtoRemove dtoRemove)
        {
            var apiUrl = $"{titlesApiURLBase}RemoveTitle";

            dtoRemove.ChangeDate = DateTime.Now;
            dtoRemove.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<TitlesDeleteResponse>(apiUrl, dtoRemove);

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
