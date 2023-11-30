using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Publicaciones.Application.Contract;
using Publicaciones.Web.ViewModels.Models;
using Publicaciones.Web.ViewModels.Responses;

namespace Publicaciones.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public string URl { set; get; } = "http://localhost:5196/api/Employee";
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            ListEmpResponse empresponse = new ListEmpResponse();


            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync($"{URl}/GetEmployees").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string APIres = response.Content.ReadAsStringAsync().Result;

                        empresponse = JsonConvert.DeserializeObject<ListEmpResponse>(APIres);
                    }
                    else
                    {
                        empresponse.Message = "Error conectandose al api.";
                        empresponse.Success = false;
                        ViewBag.Message = empresponse.Message;
                        return View();
                    }
                }
            }

            return View(empresponse.Data);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int ID)
        {
            EmpResponse empResponse = new EmpResponse();


            using (var client = new HttpClient())
            {

                var url = $"{URl}/GetEmployeesByID?ID={ID}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string APIres = response.Content.ReadAsStringAsync().Result;

                        empResponse = JsonConvert.DeserializeObject<EmpResponse>(APIres);
                    }
                    else
                    {
                        empResponse.Message = "Error conectandose al api.";
                        empResponse.Success = false;
                        ViewBag.Message = empResponse.Message;
                        return View();
                    }
                }
            }
            return View(empResponse.Data);

        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddEmpViewModel addmodel)
        {
            AddEmpResponse addempresponse = new AddEmpResponse();

            try
            {
                using (var client = new HttpClient())
                {

                    var url = $"{URl}/SaveEmployee";

                    addmodel.ChangeDate = DateTime.Now;
                    addmodel.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(addmodel), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string APIres = response.Content.ReadAsStringAsync().Result;

                            addempresponse = JsonConvert.DeserializeObject<AddEmpResponse>(APIres);
                        }
                        else
                        {
                            addempresponse.Message = "Error conectandose al api.";
                            addempresponse.Success = false;
                            ViewBag.Message = addempresponse.Message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = addempresponse.Message;
                return View();
            }
        }


        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int ID)
        {
            EmpResponse empResponse = new EmpResponse();

            using (var client = new HttpClient())
            {
                var url = $"{URl}/GetEmployeesByID?ID={ID}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string APIres = response.Content.ReadAsStringAsync().Result;
                        empResponse = JsonConvert.DeserializeObject<EmpResponse>(APIres);
                    }
                    else
                    {
                        empResponse.Message = "Error conectandose al api.";
                        empResponse.Success = false;
                        ViewBag.Message = empResponse.Message;
                        return View();
                    }
                }
            }
            return View(empResponse.Data);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateEmpViewModel empupdate)
        {
            UpdateEmpResponse updateresponse = new UpdateEmpResponse();

            try
            {
                using (var client = new HttpClient())
                {

                    var url = $"{URl}/UpdateEmployees";

                    empupdate.ChangeDate = DateTime.Now;
                    empupdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(empupdate), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PutAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string APIres = response.Content.ReadAsStringAsync().Result;

                            updateresponse = JsonConvert.DeserializeObject<UpdateEmpResponse>(APIres);
                        }
                        else
                        {
                            updateresponse.Message = "Error conectandose al api.";
                            updateresponse.Success = false;
                            ViewBag.Message = updateresponse.Message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = updateresponse.Message;
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int ID)
        {
            DeleteEmpResponse empResponse = new DeleteEmpResponse();

            using (var client = new HttpClient())
            {
                var url = $"{URl}/GetEmployeesByID?ID={ID}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string APIres = response.Content.ReadAsStringAsync().Result;
                        empResponse = JsonConvert.DeserializeObject<DeleteEmpResponse>(APIres);
                    }
                    else
                    {
                        empResponse.Message = "Error conectandose al api.";
                        empResponse.Success = false;
                        ViewBag.Message = empResponse.Message;
                        return View();
                    }
                }
            }
            return View(empResponse.Data);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DateTime ChangeDate, int ChangeUser, int ID, bool Deleted)
        {
            DeleteEmpViewModel deletemodel = new DeleteEmpViewModel()
            {
                EmpID = ID,
                ChangeDate = ChangeDate,
                ChangeUser = ChangeUser,
                Deleted = Deleted

            };

            DeleteEmpResponse deleteresponse = new DeleteEmpResponse();

            try
            {
                using (var client = new HttpClient())
                {

                    var url = $"{URl}/DeleteEmployees";

                    StringContent content = new StringContent(JsonConvert.SerializeObject(deletemodel), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string APIres = response.Content.ReadAsStringAsync().Result;

                            deleteresponse = JsonConvert.DeserializeObject<DeleteEmpResponse>(APIres);
                        }
                        else
                        {
                            deleteresponse.Message = "Error conectandose al api.";
                            deleteresponse.Success = false;
                            ViewBag.Message = deleteresponse.Message;
                            return View();
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = deleteresponse.Message;
                return View();
            }
        }
    }
}
