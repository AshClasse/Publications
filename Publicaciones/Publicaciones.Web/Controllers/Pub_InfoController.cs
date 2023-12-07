using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Web.Models.Responses;
using Publicaciones.Web.Models.Responses.Pub_Info;

namespace Publicaciones.Web.Controllers
{
    public class Pub_InfoController : Controller
	{
		private readonly IPub_InfoService _pub_infoService;
        private readonly string pubInfoApiURLBase;
        private readonly IApiService apiService;

        public Pub_InfoController(IPub_InfoService pub_InfoService, IApiService apiService, IConfiguration configuration)
		{
			this._pub_infoService = pub_InfoService;
            this.apiService = apiService;
            this.pubInfoApiURLBase = configuration["ApiSettings:Pub_InfoApiBaseUrl"];
        }

		// GET: Pub_InfoController
		public ActionResult Index()
		{
            BaseResponse<List<Pub_InfoViewResult>> responseData = apiService.GetDataFromApi<List<Pub_InfoViewResult>>($"{pubInfoApiURLBase}GetPub_Infos");

            if (responseData.success)
            {
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
        }

		// GET: Pub_InfoController/Details/5
		public ActionResult Details(int id)
		{
            BaseResponse<Pub_InfoViewResult> responseData = apiService.GetDataFromApi<Pub_InfoViewResult>($"{pubInfoApiURLBase}GetPub_InfoByID?ID={id}");

            if (responseData.success)
            {
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
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
            var apiUrl = $"{pubInfoApiURLBase}SavePub_Info";

            dtoAdd.ChangeDate = DateTime.Now;
            dtoAdd.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<Pub_InfoAddResponse>(apiUrl, dtoAdd);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

		// GET: Pub_InfoController/Edit/5
		public ActionResult Edit(int id)
		{
            BaseResponse<Pub_InfoViewResult> responseData = apiService.GetDataFromApi<Pub_InfoViewResult>($"{pubInfoApiURLBase}GetPub_InfoByID?ID={id}");

            if (responseData.success)
            {
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
        }

		// POST: Pub_InfoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(Pub_InfoDtoUpdate dtoUpdate)
		{
            var apiUrl = $"{pubInfoApiURLBase}UpdatePub_Info";

            dtoUpdate.ChangeDate = DateTime.Now;
            dtoUpdate.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<Pub_InfoUpdateResponse>(apiUrl, dtoUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: Pub_InfoController/Delete/5
        public ActionResult Delete(int id)
        {
            BaseResponse<Pub_InfoDtoRemove> responseData = apiService.GetDataFromApi<Pub_InfoDtoRemove>($"{pubInfoApiURLBase}GetPub_InfoByID?ID={id}");

            if (responseData.success)
            {
                responseData.data.Id = id;
                responseData.data.ChangeUser = 1;
                return View(responseData.data);
            }
            else
            {
                ViewBag.Message = responseData.message;
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Pub_InfoDtoRemove dtoRemove)
        {
            var apiUrl = $"{pubInfoApiURLBase}RemovePub_Info";

            dtoRemove.ChangeDate = DateTime.Now;
            dtoRemove.ChangeUser = 1;

            try
            {
                var response = apiService.PostDataToApi<Pub_InfoDeleteResponse>(apiUrl, dtoRemove);

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


