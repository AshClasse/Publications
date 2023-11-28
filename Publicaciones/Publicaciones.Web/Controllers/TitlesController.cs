using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.Dtos.Titles;
using Publicaciones.Application.Service;
using Publicaciones.Domain.Repository;
using Publicaciones.Web.Models;

namespace Publicaciones.Web.Controllers
{
    public class TitlesController : Controller
    {
		private readonly ITitlesService _titlesService;

        HttpClientHandler clientHandler = new HttpClientHandler();
        public TitlesController(ITitlesService titlesService)
		{
			this._titlesService = titlesService;
		}

		// GET: TitlesController
		public ActionResult Index()
        {
            TitlesListResponse titlesList = new TitlesListResponse();

            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5196/api/Titles/GetTitles").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        titlesList = JsonConvert.DeserializeObject<TitlesListResponse>(apiResponse);

                        if (!titlesList.success)
                        {
                            ViewBag.Message = titlesList.message;
                            return View();
                        }
                    }
                    else
                    {
                        titlesList.message = "Error conectandose al api.";
                        titlesList.success = false;
                        ViewBag.Message = titlesList.message;
                        return View();
                    }
                }
            }

            return View(titlesList.data);
        }

        // GET: TitlesController/Details/5
        public ActionResult Details(int id)
        {
            var existsResult = this._titlesService.Exists(id);

            if (!existsResult.Success)
            {
                ViewBag.Messag = existsResult.Message;
                return View();
            }

            var result = _titlesService.GetByID(id);
            if (!result.Success)
            {
                ViewBag.Messag = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: TitlesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TitlesDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                result = _titlesService.Save(dtoAdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: TitlesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TitlesController/Edit/5
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
