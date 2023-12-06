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
        private readonly IWebService webService;

        public SaleController(ISaleService saleService, IWebService webService, IConfiguration configuration)
        {
            this.saleService = saleService;
            this.webService = webService;
            this.saleApiURLBase = configuration["ApiSettings:SaleApiBaseUrl"];
        }
        public ActionResult Index()
        {
            try
            {
                BaseResponse<List<SaleViewResult>> responseData = webService.GetDataFromApi<List<SaleViewResult>>($"{saleApiURLBase}GetSales");
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
                BaseResponse<SaleViewResult> responseData = webService.GetDataFromApi<SaleViewResult>($"{saleApiURLBase}GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}");
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
                webService.PostDataToApi<BaseResponse<SaleDtoAdd>>(apiUrl, saleDtoAdd);

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
                BaseResponse<SaleViewResult> responseData = webService.GetDataFromApi<SaleViewResult>($"{saleApiURLBase}GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}");
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
                webService.PostDataToApi<BaseResponse<SaleDtoUpdate>>(apiUrl, saleDtoUpdate);

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
                BaseResponse<SaleDtoRemove> responseData = webService.GetDataFromApi<SaleDtoRemove>($"{saleApiURLBase}GetSaleByID?storeID={storeID}&ordNum={ordNum}&titleID={titleID}");
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
                webService.PostDataToApi<BaseResponse<SaleDtoRemove>>(apiUrl, dtoRemove);

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