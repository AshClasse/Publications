using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Sale;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Sale;

namespace Publicaciones.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;
        HttpClientHandler clientHandler = new HttpClientHandler();

        public SaleController(ISaleService saleService)
        {
            this.saleService = saleService;
        }
        public ActionResult Index()
        {
            SaleListResponse saleList = new SaleListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/Sale/GetSales").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        saleList = JsonConvert.DeserializeObject<SaleListResponse>(apiResponse);

                        if(!saleList.success)
                        {
                            ViewBag.Message = saleList.message;
                            return View();
                        }     
                    }
                    else
                    {
                        saleList.message = "Error connecting to API.";
                        saleList.success = false;
                        ViewBag.Message = saleList.message;
                        return View();
                    }
                }
            }
            return View(saleList.data);
        }

        public ActionResult Details(int storeID, string ordNum, int titleID)
        {
            SaleDetailsResponse saleDetailsResponse = new SaleDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Sale/GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        saleDetailsResponse = JsonConvert.DeserializeObject<SaleDetailsResponse>(apiResponse);

                        if(!saleDetailsResponse.success)
                        {
                            ViewBag.Message = saleDetailsResponse.message;
                            return View();
                        }  
                    }
                    else
                    {
                        saleDetailsResponse.message = "Error connecting to API.";
                        saleDetailsResponse.success = false;
                        ViewBag.Message = saleDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(saleDetailsResponse.data);
        }

        // GET: SaleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleDtoAdd saleDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Sale/SaveSale";

                    saleDtoAdd.ChangeDate = DateTime.Now;
                    saleDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(saleDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: SaleController/Edit/5
        public ActionResult Edit(int storeID, string ordNum, int titleID)
        {
            SaleDetailsResponse saleDetailsResponse = new SaleDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Sale/GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        saleDetailsResponse = JsonConvert.DeserializeObject<SaleDetailsResponse>(apiResponse);

                        if (!saleDetailsResponse.success)
                        {
                            ViewBag.Message = saleDetailsResponse.message;
                            return View();
                        }
                    }
                    else
                    {
                        saleDetailsResponse.message = "Error connecting to API.";
                        saleDetailsResponse.success = false;
                        ViewBag.Message = saleDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(saleDetailsResponse.data);
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleDtoUpdate saleDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Sale/UpdateSale";

                    saleDtoUpdate.ChangeDate = DateTime.Now;
                    saleDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(saleDtoUpdate), System.Text.Encoding.UTF8, "application/json");

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
