using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Authors;
using Publicaciones.Application.Dtos.TitleAuthor;
using Publicaciones.Domain.Entities;
using Publicaciones.Web.Models.Response;
using Publicaciones.Web.Models.Response.AuthorResponse;
using System;
using Publicaciones.Web.Models.Response.TitleAuthorResponse;

namespace Publicaciones.Web.Controllers
{
    public class TitleAuthorController : Controller
    {
        private readonly ITitleAuthorService titleAuthorService;
        private readonly string titleAuthorApiUrlBase;
        private readonly IApiService apiService;
        public TitleAuthorController(ITitleAuthorService titleAuthorService, IApiService apiService, IConfiguration configuration)
        {
            this.titleAuthorService = titleAuthorService;
            this.apiService = apiService;
            this.titleAuthorApiUrlBase = configuration["ApiSettings:TitleAuthorsBaseUrl"];
        }
        // GET: TitleAuthorController
        public ActionResult Index()
        {
            BaseResponse<List<TitleAuthorViewResult>> responseData = apiService.GetDataFromApi<List<TitleAuthorViewResult>>($"{titleAuthorApiUrlBase}GetTitlesAuthors\r\n");

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

        // GET: TitleAuthorController/Details/5
        public ActionResult Details(int au_id, int title_id)
        {
            BaseResponse<TitleAuthorViewResult> responseData = apiService.GetDataFromApi<TitleAuthorViewResult>($"{titleAuthorApiUrlBase}GetTitlesAuthorByID?title_ID={title_id}&author_ID={au_id}\r\n");

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

        // GET: TitleAuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitleAuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TitleAuthorDtoAdd titleAuthorDtoAdd)
        {
            var apiUrl = $"{titleAuthorApiUrlBase}SaveTitleAuthor\r\n";

            titleAuthorDtoAdd.ChangeDate = DateTime.Now;
            titleAuthorDtoAdd.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<TitleAuthorAddResponse>(apiUrl, titleAuthorDtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: TitleAuthorController/Edit/5
        public ActionResult Edit(int au_id, int title_id)
        {
            BaseResponse<TitleAuthorViewResult> responseData = apiService.GetDataFromApi<TitleAuthorViewResult>($"{titleAuthorApiUrlBase}GetTitlesAuthorByID?title_ID={title_id}&author_ID={au_id}\r\n");

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

        // POST: TitleAuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TitleAuthorDtoUpdate titleAuthorDtoUpdate)
        {
            var apiUrl = $"{titleAuthorApiUrlBase}UpdateTitleAuthor\r\n";

            titleAuthorDtoUpdate.ChangeDate = DateTime.Now;
            titleAuthorDtoUpdate.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<TitleAuthorUpdateResponse>(apiUrl, titleAuthorDtoUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }

        }

        // GET: TitleAuthorController/Delete/5
        public ActionResult Delete(int title_id, int au_id)
        {
            BaseResponse<TitleAuthorDtoRemove> responseData = apiService.GetDataFromApi<TitleAuthorDtoRemove>($"{titleAuthorApiUrlBase}GetTitlesAuthorByID?title_ID={title_id}&author_ID={au_id}\r\n");
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

        // POST: TitleAuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TitleAuthorDtoRemove titleAuthorDtoRemove)
        {
            var apiUrl = $"{titleAuthorApiUrlBase}RemoveTitleAuthor\r\n";

            titleAuthorDtoRemove.ChangeDate = DateTime.Now;
            titleAuthorDtoRemove.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<TitleAuthorDeleteResponse>(apiUrl, titleAuthorDtoRemove);

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
