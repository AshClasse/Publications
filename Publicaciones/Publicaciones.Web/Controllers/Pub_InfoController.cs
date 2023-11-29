using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Pub_Info;
using System.Collections;
using System.Security.Policy;

namespace Publicaciones.Web.Controllers
{
    public class Pub_InfoController : Controller
	{
		private readonly IPub_InfoService _pub_infoService;

        HttpClientHandler clientHandler = new HttpClientHandler();
        public Pub_InfoController(IPub_InfoService pub_InfoService)
		{
			this._pub_infoService = pub_InfoService;
		}

		// GET: Pub_InfoController
		public ActionResult Index()
		{
            Pub_InfoListResponse pubInfoList = new Pub_InfoListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/Pub_Info/GetPub_Infos").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        pubInfoList = JsonConvert.DeserializeObject<Pub_InfoListResponse>(apiResponse);

                        if (!pubInfoList.success)
                        {
                            ViewBag.Message = pubInfoList.message;
                            return View();
                        }
                    }
                    else
                    {
                        pubInfoList.message = "Error connecting to API.";
                        pubInfoList.success = false;
                        ViewBag.Message = pubInfoList.message;
                        return View();
                    }
                }
            }

            return View(pubInfoList.data);
        }

		// GET: Pub_InfoController/Details/5
		public ActionResult Details(int id)
		{
            Pub_InfoDetailsResponse pubInfoDetailsResponse = new Pub_InfoDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Pub_Info/GetPub_InfoByID?ID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        pubInfoDetailsResponse = JsonConvert.DeserializeObject<Pub_InfoDetailsResponse>(apiResponse);

                        if (!pubInfoDetailsResponse.success)
                        {
                            ViewBag.Message = pubInfoDetailsResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        pubInfoDetailsResponse.message = "Error connecting to API.";
                        pubInfoDetailsResponse.success = false;
                        ViewBag.Message = pubInfoDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(pubInfoDetailsResponse.data);
        }

		// GET: Pub_InfoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Pub_InfoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Pub_InfoDtoAdd dtoAdd)
		{
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Pub_Info/SavePub_Info";

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

		// GET: Pub_InfoController/Edit/5
		public ActionResult Edit(int id)
		{
            Pub_InfoUpdateResponse updateResponse = new Pub_InfoUpdateResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Pub_Info/GetPub_InfoByID?ID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        updateResponse = JsonConvert.DeserializeObject<Pub_InfoUpdateResponse>(apiResponse);

                        if (!updateResponse.success)
                        {
                            ViewBag.Message = updateResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        updateResponse.message = "Error connecting to API.";
                        updateResponse.success = false;
                        ViewBag.Message = updateResponse.message;
                        return View();
                    }
                }
            }

            return View(updateResponse.data);
        }

		// POST: Pub_InfoController/Edit/5
		[HttpPut]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Pub_InfoDtoUpdate dtoUpdate)
		{
            Pub_InfoUpdateResponse updateResponse = new Pub_InfoUpdateResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Pub_Info/UpdatePub_Info";

                    dtoUpdate.ChangeDate = DateTime.Now;
                    dtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(dtoUpdate), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PutAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            updateResponse = JsonConvert.DeserializeObject<Pub_InfoUpdateResponse>(apiResponse);

                            if (!updateResponse.success)
                            {
                                ViewBag.Message = updateResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            updateResponse.message = "Error connecting to API.";
                            updateResponse.success = false;
                            ViewBag.Message = updateResponse.message;
                            return View();
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = updateResponse.message;
                return View();
            }
        }

        // GET: Pub_InfoController/Delete/5
        public ActionResult Delete(int id)
        {
            Pub_InfoDeleteResponse removeResponse = new Pub_InfoDeleteResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Pub_Info/GetPub_InfoByID?ID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        removeResponse = JsonConvert.DeserializeObject<Pub_InfoDeleteResponse>(apiResponse);

                        if (!removeResponse.success)
                        {
                            ViewBag.Message = removeResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        removeResponse.message = "Error connecting to API.";
                        removeResponse.success = false;
                        ViewBag.Message = removeResponse.message;
                        return View();
                    }
                }
            }

            return View(removeResponse.data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Pub_InfoDtoRemove dtoRemove)
        {
            Pub_InfoDeleteResponse removeResponse = new Pub_InfoDeleteResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {
                    var url = $"http://localhost:5196/api/Pub_Info/RemovePub_Info";

                    dtoRemove.ChangeDate = DateTime.Now;
                    dtoRemove.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(dtoRemove), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            removeResponse = JsonConvert.DeserializeObject<Pub_InfoDeleteResponse>(apiResponse);

                            if (!removeResponse.success)
                            {
                                ViewBag.Message = removeResponse.message;
                                return View();
                            }
                        }
                        else
                        {
                            removeResponse.message = "Error connecting to API.";
                            removeResponse.success = false;
                            ViewBag.Message = removeResponse.message;
                            return View();
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = removeResponse.message;
                return View();
            }

        }
    }
}


