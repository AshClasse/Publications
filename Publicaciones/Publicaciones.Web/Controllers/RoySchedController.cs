using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.RoySched;
using Publicaciones.Application.Service;
using Publicaciones.Web.Models;

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
                        roySchedList.message = "Error conectandose al api.";
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

            var result = _roySchedService.GetByID(id);
            if (!result.Success)
            {
                ViewBag.Messag = result.Message;
                return View();
            }
            return View(result.Data);
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
            ServiceResult result = new ServiceResult();

            try
            {
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                result = _roySchedService.Save(dtoAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

		// GET: RoySchedController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: RoySchedController/Edit/5
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
