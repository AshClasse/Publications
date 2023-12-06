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
        HttpClientHandler clientHandler = new HttpClientHandler();
        public AuthorController(IAuthorsService authorsService) 
        {
            this.authorsService = authorsService;   
        }

        // GET: AuthorController

        public ActionResult Index()
        {
            AuthorsListResponse authorsListResponse = new AuthorsListResponse();
            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/Authors/GetAuthors\r\n").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        authorsListResponse = JsonConvert.DeserializeObject<AuthorsListResponse>(apiResponse);
                        if (!authorsListResponse.success)
                            ViewBag.Message = authorsListResponse.message;
                    }
                }
            }
            return View(authorsListResponse.data);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            AuthorDetailResponse authorsDetailResponse = new AuthorDetailResponse();
            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Authors/GetAuthorByID?ID={id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        authorsDetailResponse = JsonConvert.DeserializeObject<AuthorDetailResponse>(apiResponse);
                        if (!authorsDetailResponse.success)
                            ViewBag.Message = authorsDetailResponse.message;
                    }
                }
            }
            return View(authorsDetailResponse.data);
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
            ServiceResult result = new ServiceResult();
            try
            {
                result = this.authorsService.Save(authorsDtoAdd);
                if(!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            AuthorEditResponse authorEditResponse = new AuthorEditResponse();
            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Authors/GetAuthorByID?ID={id}";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        authorEditResponse = JsonConvert.DeserializeObject<AuthorEditResponse>(apiResponse);
                        if (!authorEditResponse.success)
                            ViewBag.Message = authorEditResponse.message;
                    }
                }
            }
            return View(authorEditResponse.data);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorsDtoUpdate authorsDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                authorsDtoUpdate.ChangeDate = DateTime.Now;
                authorsDtoUpdate.ChangeUser = 1;
                AuthorDetailResponse authorDetailResponse = new AuthorDetailResponse();
                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5196/api/Authors/UpdateAuthor\r\n";

                    StringContent content = new StringContent(JsonConvert.SerializeObject(authorsDtoUpdate), System.Text.Encoding.UTF8, "application/json");
                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                            if (!baseResponse.success)
                                ViewBag.Message = baseResponse.message;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorController/Delete/5
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
