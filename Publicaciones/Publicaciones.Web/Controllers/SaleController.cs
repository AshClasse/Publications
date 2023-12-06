using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Sale;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Discount;
using Publicaciones.Web.Models.Responses.Sale;
using Publicaciones.Web.Service;

namespace Publicaciones.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;
        private readonly string saleApiURLBase;
        private readonly IApiService apiService;

        public SaleController(ISaleService saleService, IApiService apiService, IConfiguration configuration)
        {
            this.saleService = saleService;
            this.apiService = apiService;
            this.saleApiURLBase = configuration["ApiSettings:SaleApiBaseUrl"];
        }
        public ActionResult Index()
        {
            try
            {
                BaseResponse<List<SaleViewResult>> responseData = apiService.GetDataFromApi<List<SaleViewResult>>($"{saleApiURLBase}GetSales");
                return View(responseData.data);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public ActionResult Details(int storeID, string ordNum, int titleID)
        {
            try
            {
                BaseResponse<SaleViewResult> responseData = apiService.GetDataFromApi<SaleViewResult>($"{saleApiURLBase}GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}");
                return View(responseData.data);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
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
            var apiUrl = $"{saleApiURLBase}SaveSale";

            saleDtoAdd.ChangeDate = DateTime.Now;
            saleDtoAdd.ChangeUser = 1;

            try
            {
                apiService.PostDataToApi<BaseResponse<SaleDtoAdd>>(apiUrl, saleDtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: SaleController/Edit/5
        public ActionResult Edit(int storeID, string ordNum, int titleID)
        {
            try
            {
                BaseResponse<SaleViewResult> responseData = apiService.GetDataFromApi<SaleViewResult>($"{saleApiURLBase}GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}");
                return View(responseData.data);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // POST: SaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaleDtoUpdate saleDtoUpdate)
        {
            var apiUrl = $"{saleApiURLBase}UpdateSale";

            saleDtoUpdate.ChangeDate = DateTime.Now;
            saleDtoUpdate.ChangeUser = 1;

            try
            {
                apiService.PostDataToApi<BaseResponse<SaleDtoUpdate>>(apiUrl, saleDtoUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Pub_InfoController/Delete/5
        public ActionResult Delete(int storeID, string ordNum, int titleID)
        {
            try
            {
                BaseResponse<SaleDtoRemove> responseData = apiService.GetDataFromApi<SaleDtoRemove>($"{saleApiURLBase}GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}");
                return View(responseData.data);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SaleDtoRemove dtoRemove)
        {
            var apiUrl = $"{saleApiURLBase}RemoveSale";

            dtoRemove.ChangeDate = DateTime.Now;
            dtoRemove.ChangeUser = 1;

            try
            {
                apiService.PostDataToApi<BaseResponse<SaleDtoRemove>>(apiUrl, dtoRemove);

                return RedirectToAction(nameof(Index));
            }
            catch(ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}