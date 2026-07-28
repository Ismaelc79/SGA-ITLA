using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces.Trip;
using SGA.Web.App.Models;


namespace SGA.Web.App.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;
        public BusController(IBusService busService)
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

            var viewModel = buses.Data.Select(b => new BusViewModel
            {
                Id = b.Id,
                ConductorId = b.ConductorId,
                Placa = b.Placa,
                Marca = b.Marca,
                Modelo = b.Modelo,
                Capacidad = b.Capacidad,
                EstadoBus = b.EstadoBus
            });

            return View(viewModel);
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