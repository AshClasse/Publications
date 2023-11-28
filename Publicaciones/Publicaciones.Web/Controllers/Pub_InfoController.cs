using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Pub_Info;
using Publicaciones.Web.Models;
using System.Collections;

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
                        pubInfoList.message = "Error conectandose al api.";
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
            var existsResult = this._pub_infoService.Exists(id);

            if (!existsResult.Success)
            {
                ViewBag.Messag = existsResult.Message;
                return View();
            }

            var result = _pub_infoService.GetByID(id);
            if (!result.Success)
            {
                ViewBag.Messag = result.Message;
                return View();
            }
            return View(result.Data);
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
            ServiceResult result = new ServiceResult();

            try
            {
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                result = _pub_infoService.Save(dtoAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

		// GET: Pub_InfoController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Pub_InfoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

	}
}
