using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Application.Service;
using Publicaciones.Domain.Repository;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.RoySched;
using Publicaciones.Web.Models.Responses.Titles;

namespace Publicaciones.Web.Controllers
{
    public class TitlesController : Controller
    {
		private readonly ITitlesService _titlesService;

        HttpClientHandler clientHandler = new HttpClientHandler();
        public TitlesController(ITitlesService titlesService)
		{
			this._titlesService = titlesService;
		}

		// GET: TitlesController
		public ActionResult Index()
        {
            TitlesListResponse titlesList = new TitlesListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/Titles/GetTitles").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        titlesList = JsonConvert.DeserializeObject<TitlesListResponse>(apiResponse);

                        if (!titlesList.success)
                        {
                            ViewBag.Message = titlesList.message;
                            return View();
                        }
                    }
                    else
                    {
                        titlesList.message = "Error connecting to API.";
                        titlesList.success = false;
                        ViewBag.Message = titlesList.message;
                        return View();
                    }
                }
            }

            return View(titlesList.data);
        }

        // GET: TitlesController/Details/5
        public ActionResult Details(int id)
        {
            TitlesDetailsResponse titlesDetailsResponse = new TitlesDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Titles/GetTitleByID?ID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        titlesDetailsResponse = JsonConvert.DeserializeObject<TitlesDetailsResponse>(apiResponse);

                        if (!titlesDetailsResponse.success)
                        {
                            ViewBag.Message = titlesDetailsResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        titlesDetailsResponse.message = "Error connecting to API.";
                        titlesDetailsResponse.success = false;
                        ViewBag.Message = titlesDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(titlesDetailsResponse.data);
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
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Titles/SaveTitle";

                    dtoAdd.ChangeDate = DateTime.Now;
                    dtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(dtoAdd), System.Text.Encoding.UTF8, "application/json");

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
                            baseResponse.message = "Error connecting to API.";
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

        // GET: TitlesController/Edit/5
        public ActionResult Edit(int id)
        {
            TitlesDetailsResponse titlesDetailsResponse = new TitlesDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Titles/GetTitleByID?ID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        titlesDetailsResponse = JsonConvert.DeserializeObject<TitlesDetailsResponse>(apiResponse);

                        if (!titlesDetailsResponse.success)
                        {
                            ViewBag.Message = titlesDetailsResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        titlesDetailsResponse.message = "Error connecting to API.";
                        titlesDetailsResponse.success = false;
                        ViewBag.Message = titlesDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(titlesDetailsResponse.data);
        }

        // POST: TitlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TitlesDtoUpdate dtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Titles/UpdateTitle";

                    dtoUpdate.ChangeDate = DateTime.Now;
                    dtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(dtoUpdate), System.Text.Encoding.UTF8, "application/json");

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
                            baseResponse.message = "Error connecting to API.";
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
    }
}
