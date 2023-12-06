using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Authors;
using Publicaciones.Application.Dtos.TitleAuthor;
using Publicaciones.Web.Models.Response;
using Publicaciones.Web.Models.Response.AuthorResponse;
using Publicaciones.Web.Models.Response.TitleAuthorResponse;

namespace Publicaciones.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorsService authorsService;
        private readonly string authorsApiURLBase;
        private readonly IApiService apiService;
        public AuthorController(IAuthorsService authorsService, IApiService apiService, IConfiguration configuration) 
        {
            this.authorsService = authorsService;
            this.apiService = apiService;
            this.authorsApiURLBase = configuration["ApiSettings:AuthorsApiBaseUrl"];
        }

        // GET: AuthorController

        public ActionResult Index()
        {
            BaseResponse<List<AuthorsViewResult>> responseData = apiService.GetDataFromApi<List<AuthorsViewResult>>($"{authorsApiURLBase}GetAuthors\r\n");
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

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            BaseResponse<AuthorsViewResult> responseData = apiService.GetDataFromApi<AuthorsViewResult>($"{authorsApiURLBase}GetAuthorByID?ID={id}");

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

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorsDtoAdd authorsDtoAdd)
        {
            var apiUrl = $"{authorsApiURLBase}SaveAuthor";

            authorsDtoAdd.ChangeDate = DateTime.Now;
            authorsDtoAdd.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<AuthorsDtoAdd>(apiUrl, authorsDtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            BaseResponse<AuthorsViewResult> responseData = apiService.GetDataFromApi<AuthorsViewResult>($"{authorsApiURLBase}GetAuthorByID?ID={id}");

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

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorsDtoUpdate authorsDtoUpdate)
        {
            var apiUrl = $"{authorsApiURLBase}UpdateAuthor\r\n";

            authorsDtoUpdate.ChangeDate = DateTime.Now;
            authorsDtoUpdate.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<AuthorUpdateResponse>(apiUrl, authorsDtoUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }

        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            BaseResponse<AuthorsDtoRemove> responseData = apiService.GetDataFromApi<AuthorsDtoRemove>($"{authorsApiURLBase}GetAuthorByID?ID={id}");

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

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AuthorsDtoRemove authorsDtoRemove)
        {
            var apiUrl = $"{authorsApiURLBase}DeleteAuthor";

            authorsDtoRemove.ChangeDate = DateTime.Now;
            authorsDtoRemove.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<AuthorDeleteResponse>(apiUrl, authorsDtoRemove);

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
