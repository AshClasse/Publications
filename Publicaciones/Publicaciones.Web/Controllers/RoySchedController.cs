using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
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

        HttpClientHandler clientHandler = new HttpClientHandler();
        public RoySchedController(IRoySchedService roySchedService)
		{
			this._roySchedService = roySchedService;
		}

		// GET: RoySchedController
		public ActionResult Index()
		{
            RoySchedListResponse roySchedList = new RoySchedListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/RoySched/GetRoyScheds").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        roySchedList = JsonConvert.DeserializeObject<RoySchedListResponse>(apiResponse);

                        if (!roySchedList.success)
                        {
                            ViewBag.Message = roySchedList.message;
                            return View();
                        }
                    }
                    else
                    {
                        roySchedList.message = "Error connecting to API.";
                        roySchedList.success = false;
                        ViewBag.Message = roySchedList.message;
                        return View();
                    }
                }
            }

            return View(roySchedList.data);
        }

		// GET: RoySchedController/Details/5
		public ActionResult Details(int id)
		{

            RoySchedDetailsResponse roySchedDetailsResponse = new RoySchedDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/RoySched/GetRoySchedByID?ID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        roySchedDetailsResponse = JsonConvert.DeserializeObject<RoySchedDetailsResponse>(apiResponse);

                        if (!roySchedDetailsResponse.success)
                        {
                            ViewBag.Message = roySchedDetailsResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        roySchedDetailsResponse.message = "Error connecting to API.";
                        roySchedDetailsResponse.success = false;
                        ViewBag.Message = roySchedDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(roySchedDetailsResponse.data);
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
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/RoySched/SaveRoySched";

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

		// GET: RoySchedController/Edit/5
		public ActionResult Edit(int id)
		{
            RoySchedDetailsResponse roySchedDetailsResponse = new RoySchedDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/RoySched/GetRoySchedByID?ID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        roySchedDetailsResponse = JsonConvert.DeserializeObject<RoySchedDetailsResponse>(apiResponse);

                        if (!roySchedDetailsResponse.success)
                        {
                            ViewBag.Message = roySchedDetailsResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        roySchedDetailsResponse.message = "Error connecting to API.";
                        roySchedDetailsResponse.success = false;
                        ViewBag.Message = roySchedDetailsResponse.message;
                        return View();
                    }
                }
            }
            return View(roySchedDetailsResponse.data);
        }

		// POST: RoySchedController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(RoySchedDtoUpdate dtoUpdate)
		{
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/RoySched/UpdateRoySched";

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
