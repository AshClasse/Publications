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
        HttpClientHandler clientHandler = new HttpClientHandler();
        public TitleAuthorController(ITitleAuthorService titleAuthorService)
        {
            this.titleAuthorService = titleAuthorService;
        }
        // GET: TitleAuthorController
        public ActionResult Index()
        {
            TitleAuthorListResponse titleAuthorList = new TitleAuthorListResponse();
            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/TitleAuthor/GetTitlesAuthors\r\n").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        titleAuthorList = JsonConvert.DeserializeObject<TitleAuthorListResponse>(apiResponse);
                        if (!titleAuthorList.success)
                        {
                            ViewBag.Message = titleAuthorList.message;
                            return View();
                        }
                    }
                    else
                    {
                        titleAuthorList.message = "Error connecting to API";
                        titleAuthorList.success = false;
                        ViewBag.Message = titleAuthorList.message;
                        return View();
                    }
                }
            }
            return View(titleAuthorList.data);
        }

        // GET: TitleAuthorController/Details/5
        public ActionResult Details(int au_id, int title_id)
        {
            TitleAuthorDetailResponse titleAuthorDetailResponse = new TitleAuthorDetailResponse();
            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/TitleAuthor/GetTitlesAuthorByID?title_ID={title_id}&author_ID={au_id}\r\n";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        titleAuthorDetailResponse = JsonConvert.DeserializeObject<TitleAuthorDetailResponse>(apiResponse);
                        if (!titleAuthorDetailResponse.success)
                        {
                            ViewBag.Message = titleAuthorDetailResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        titleAuthorDetailResponse.message = "Error connecting to API";
                        titleAuthorDetailResponse.success = false;
                        ViewBag.Message = titleAuthorDetailResponse.message;
                    }
                }
            }
            return View(titleAuthorDetailResponse.data);
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
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                TitleAuthorDetailResponse titleAuthorDetailResponse = new TitleAuthorDetailResponse();
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/TitleAuthor/SaveTitleAuthor\r\n";
                    titleAuthorDtoAdd.ChangeDate = DateTime.Now;
                    titleAuthorDtoAdd.ChangeUser = 1;
                    StringContent content = new StringContent(JsonConvert.SerializeObject(titleAuthorDtoAdd), System.Text.Encoding.UTF8, "application/json");
                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            baseResponse.message = "Error connecting to API";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: TitleAuthorController/Edit/5
        public ActionResult Edit(int au_id, int title_id)
        {
            TitleAuthorEditResponse titleAuthorEditResponse = new TitleAuthorEditResponse();
            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/TitleAuthor/GetTitlesAuthorByID?title_ID={title_id}&author_ID={au_id}\r\n";
                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        titleAuthorEditResponse = JsonConvert.DeserializeObject<TitleAuthorEditResponse>(apiResponse);
                        if (!titleAuthorEditResponse.success)
                            ViewBag.Message = titleAuthorEditResponse.message;
                    }
                    else
                    {
                        titleAuthorEditResponse.message = "Error connecting to API";
                        titleAuthorEditResponse.success = false;
                        ViewBag.Message = titleAuthorEditResponse.message;
                    }
                }
            }
            return View(titleAuthorEditResponse.data);
        }

        // POST: TitleAuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TitleAuthorDtoUpdate titleAuthorDtoUpdate)
        {
            titleAuthorDtoUpdate.ChangeDate = DateTime.Now;
            titleAuthorDtoUpdate.ChangeUser = 1;
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                TitleAuthorDetailResponse titleAuthorDetailResponse = new TitleAuthorDetailResponse();
                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5196/api/TitleAuthor/UpdateTitleAuthor\r\n";

                    StringContent content = new StringContent(JsonConvert.SerializeObject(titleAuthorDtoUpdate), System.Text.Encoding.UTF8, "application/json");
                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);
                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            baseResponse.message = "Error connecting to API";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: TitleAuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TitleAuthorController/Delete/5
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
