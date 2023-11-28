using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Discount;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Discount;

namespace Publicaciones.Web.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService discountService;
        HttpClientHandler clientHandler = new HttpClientHandler();

        public DiscountController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        // GET: DiscountController
        public ActionResult Index()
        {
            DiscountListResponse discountList = new DiscountListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/Discount/GetDiscounts").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        discountList = JsonConvert.DeserializeObject<DiscountListResponse>(apiResponse);

                        if(!discountList.success)
                        {
                            ViewBag.Message = discountList.message;
                            return View();
                        } 
                    }
                    else
                    {
                        discountList.message = "Error connecting to API.";
                        discountList.success = false;
                        ViewBag.Message = discountList.message;
                        return View();
                    }
                }
            }

            return View(discountList.data);
        }

        // GET: DiscountController/Details/5
        public ActionResult Details(int id)
        {
            DiscountDetailsResponse discountDetailsResponse = new DiscountDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Discount/GetDiscountByID?discountID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        discountDetailsResponse = JsonConvert.DeserializeObject<DiscountDetailsResponse>(apiResponse);

                        if (!discountDetailsResponse.success)
                        {
                            ViewBag.Message = discountDetailsResponse.message;
                            return View();
                        }    
                    }
                    else
                    {
                        discountDetailsResponse.message = "Error connecting to API.";
                        discountDetailsResponse.success = false;
                        ViewBag.Message = discountDetailsResponse.message;
                        return View();
                    }
                }
            }

            return View(discountDetailsResponse.data);
        }

        // GET: DiscountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiscountDtoAdd discountDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Discount/SaveDiscount";

                    discountDtoAdd.ChangeDate = DateTime.Now;
                    discountDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(discountDtoAdd), System.Text.Encoding.UTF8, "application/json");

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

        // GET: DiscountController/Edit/5
        public ActionResult Edit(int id)
        {
            DiscountDetailsResponse discountDetailsResponse = new DiscountDetailsResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                var url = $"http://localhost:5196/api/Discount/GetDiscountByID?discountID={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        discountDetailsResponse = JsonConvert.DeserializeObject<DiscountDetailsResponse>(apiResponse);

                        if (!discountDetailsResponse.success)
                        {
                            ViewBag.Message = discountDetailsResponse.message;
                            return View();
                        }    
                    }
                    else
                    {
                        discountDetailsResponse.message = "Error connecting to API.";
                        discountDetailsResponse.success = false;
                        ViewBag.Message = discountDetailsResponse.message;
                        return View();
                    }
                }
            }
            return View(discountDetailsResponse.data);
        }

        // POST: DiscountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiscountDtoUpdate discountDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {
                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5196/api/Discount/UpdateDiscount";

                    discountDtoUpdate.ChangeDate = DateTime.Now;
                    discountDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(discountDtoUpdate), System.Text.Encoding.UTF8, "application/json");

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
