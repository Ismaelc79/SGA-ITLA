using Microsoft.AspNetCore.Mvc;
using SGA.Application.Services.Trips;


namespace SGA.Web.App.Controllers
{
    public class BusController : Controller
    {
        private readonly BusService _busService;
        public BusController(BusService busService)
        {
            _busService = busService;
        }


        // GET: BusController
        public async Task<IActionResult> Index()
        {
            var buses = await _busService.GetAllAsync();
            if (!buses.Success)
            {
                ViewBag.Message = buses.Message;
                return View();
            }

            return View(buses.Data);
        }

        // GET: BusController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BusController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BusController/Edit/5
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

        // GET: BusController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
