using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Store;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Store;

namespace Publicaciones.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService storeService;
        HttpClientHandler clientHandler = new HttpClientHandler();

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        public ActionResult Index()
        {
            StoreListResponse storeList = new StoreListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/Store/GetStores").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        storeList = JsonConvert.DeserializeObject<StoreListResponse>(apiResponse);

                        if(!storeList.success)
                        {
                            ViewBag.Message = storeList.message;
                            return View();
                        }   
                    }
                    else
                    {
                        storeList.message = "Error connecting to API.";
                        storeList.success = false;
                        ViewBag.Message = storeList.message;
                        return View();
                    }
                }
            }

            return View(storeList.data);
        }

        // GET: StoreController/Details/5
        public ActionResult Details(int id)
        {
            StoreDetailsResponse storeDetailsResponse = new StoreDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Store/GetStoreByID?storeID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        storeDetailsResponse = JsonConvert.DeserializeObject<StoreDetailsResponse>(apiResponse);

                        if(!storeDetailsResponse.success)
                        {
                            ViewBag.Message = storeDetailsResponse.message;
                            return View();
                        }  
                    }
                    else
                    {
                        storeDetailsResponse.message = "Error connecting to API.";
                        storeDetailsResponse.success = false;
                        ViewBag.Message = storeDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(storeDetailsResponse.data);
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoreDtoAdd storeDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Store/SaveStore";

                    storeDtoAdd.ChangeDate = DateTime.Now;
                    storeDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(storeDtoAdd), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        Console.WriteLine(response.StatusCode);
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

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            StoreDetailsResponse storeDetailsResponse = new StoreDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Store/GetStoreByID?storeID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        storeDetailsResponse = JsonConvert.DeserializeObject<StoreDetailsResponse>(apiResponse);

                        if (!storeDetailsResponse.success)
                        {
                            ViewBag.Message = storeDetailsResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        storeDetailsResponse.message = "Error connecting to API.";
                        storeDetailsResponse.success = false;
                        ViewBag.Message = storeDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(storeDetailsResponse.data);
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreDtoUpdate storeDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Store/UpdateStore";

                    storeDtoUpdate.ChangeDate = DateTime.Now;
                    storeDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(storeDtoUpdate), System.Text.Encoding.UTF8, "application/json");

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
