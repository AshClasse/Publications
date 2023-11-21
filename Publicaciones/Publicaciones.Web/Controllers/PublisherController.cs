using Microsoft.AspNetCore.Mvc;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Publishers;

namespace Publicaciones.Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }
        // GET: PublisherController
        public ActionResult Index()
        {
            var result = _publisherService.GetAll();
            if (!result.Success)
            {
                ViewBag.Message = result.Message ; 
                return View();
            }
            return View(result.Data);
        }

        // GET: PublisherController/Details/5
        public ActionResult Details(int ID)
        {
            var result = _publisherService.GetByID(ID);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return View(result.Data);
        }

        // GET: PublisherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublisherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = _publisherService.Save(dtoadd);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: PublisherController/Edit/5
        public ActionResult Edit(int ID)
        {
            var result = _publisherService.GetByID(ID);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var datos = (PublisherDtoGetAll)result.Data;
            PublisherDtoUpdate dtoupdate = new PublisherDtoUpdate()
            {
                PubID = datos.PubID,
                PubName = datos.PubName,
                Country = datos.Country,
                State = datos.State,
                City = datos.City,
                ChangeDate = datos.ChangeDate,
                ChangeUser  = datos.ChangeUser
            };
            return View(dtoupdate);
        }

        // POST: PublisherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublisherDtoUpdate dtoupdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result = _publisherService.Update(dtoupdate);
                if(!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: PublisherController/Delete/5
        public ActionResult Delete(int ID)
        {
            var result = _publisherService.GetByID(ID);
            if(!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var datos = (PublisherDtoGetAll) result.Data;
            PublisherDtoRemove dtoremove = new PublisherDtoRemove()
            {
                PubID = datos.PubID,
                ChangeDate = datos.ChangeDate,
                ChangeUser = datos.ChangeUser,
            };
            return View(dtoremove);
        }

        // POST: PublisherController/Delete/5
        [ValidateAntiForgeryToken]
        [HttpPost ]
        public ActionResult Delete(int PubID, int ChangeUser, DateTime ChangeDate , bool Deleted)
        {
            PublisherDtoRemove pubdtoremove = new PublisherDtoRemove()
            {
                Deleted = Deleted,
                ChangeDate = ChangeDate,
                PubID = PubID,
                ChangeUser = ChangeUser,
            };

            ServiceResult result = new ServiceResult();
            try
            {
                result = _publisherService.Remove(pubdtoremove);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }
    }
}
