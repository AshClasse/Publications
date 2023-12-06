using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Discount;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Discount;
using Publicaciones.Web.Service;

namespace Publicaciones.Web.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService discountService;
        private readonly string discountApiURLBase;
        private readonly IWebService webService;

        public DiscountController(IDiscountService discountService, IWebService webService, IConfiguration configuration)
        {
            this.discountService = discountService;
            this.webService = webService;
            this.discountApiURLBase = configuration["ApiSettings:DiscountApiBaseUrl"];
        }

        // GET: DiscountController
        public ActionResult Index()
        {
            try
            {
                BaseResponse<List<DiscountViewResult>> responseData = webService.GetDataFromApi<List<DiscountViewResult>>($"{discountApiURLBase}GetDiscounts");
                return View(responseData.data);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: DiscountController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                BaseResponse<DiscountViewResult> responseData = webService.GetDataFromApi<DiscountViewResult>($"{discountApiURLBase}GetDiscountByID?discountID={id}");
                return View(responseData.data);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
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
            var apiUrl = $"{discountApiURLBase}SaveDiscount";

            discountDtoAdd.ChangeDate = DateTime.Now;
            discountDtoAdd.ChangeUser = 1;

            try
            {
                webService.PostDataToApi<BaseResponse<DiscountDtoAdd>>(apiUrl, discountDtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: DiscountController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                BaseResponse<DiscountViewResult> responseData = webService.GetDataFromApi<DiscountViewResult>($"{discountApiURLBase}GetDiscountByID?discountID={id}");
                return View(responseData.data);
            }
            catch(Exception ex) 
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: DiscountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DiscountDtoUpdate discountDtoUpdate)
        {
            var apiUrl = $"{discountApiURLBase}UpdateDiscount";

            discountDtoUpdate.ChangeDate = DateTime.Now;
            discountDtoUpdate.ChangeUser = 1;

            try
            {
                webService.PostDataToApi<BaseResponse<DiscountDtoUpdate>>(apiUrl, discountDtoUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                BaseResponse<DiscountDtoRemove> responseData = webService.GetDataFromApi<DiscountDtoRemove>($"{discountApiURLBase}GetDiscountByID?discountID={id}");
                return View(responseData.data);
            }
            catch( Exception ex )
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DiscountDtoRemove discountDtoRemove)
        {
            var apiUrl = $"{discountApiURLBase}RemoveDiscount";

            discountDtoRemove.ChangeDate = DateTime.Now;
            discountDtoRemove.ChangeUser = 1;

            try
            {
                webService.PostDataToApi<BaseResponse<DiscountDtoRemove>>(apiUrl, discountDtoRemove);

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