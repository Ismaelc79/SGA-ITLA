using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.DTOs.Bus;
using SGA.Application.Interfaces.Trip;
using SGA.Domain.Enums;
using SGA.Application.Exceptions;

namespace SGA.Web.App.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        // GET: Bus
        public async Task<IActionResult> Index(string? placa)
        {
            var buses = await _busService.GetAllAsync();

            if (!buses.Success)
            {
                ViewBag.Error = buses.Message;
                return View(new List<BusDto>());
            }

            IEnumerable<BusDto> resultado = buses.Data!;

            if (!string.IsNullOrWhiteSpace(placa))
            {
                resultado = resultado.Where(b =>
                    b.Placa != null &&
                    b.Placa.Contains(placa, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.Placa = placa;

            return View(resultado.ToList());
        }

        // GET: Bus/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bus = await _busService.GetByIdAsync(id);

            if (!bus.Success)
            {
                ViewBag.Error = bus.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(bus.Data);
        }

        // GET: Bus/Create
        public IActionResult Create()
        {
            return View(new CreateBusDto());
        }

        // POST: Bus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBusDto bus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(bus);
                }

                var resultado = await _busService.CreateAsync(bus);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    return View(bus);
                }

                return RedirectToAction(nameof(Index));
            }

            catch(BusinessRuleException ex)
            {
                ViewBag.Error = ex.Message;
                return View(bus);
            }
        }

        // GET: Bus/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var bus = await _busService.GetByIdAsync(id);

            if (!bus.Success)
            {
                ViewBag.Error = bus.Message;
                return RedirectToAction(nameof(Index));
            }

            var dto = bus.Data!;

            var editar = new UpdateBusDto
            {
                ConductorId = dto.ConductorId,
                Placa = dto.Placa,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Capacidad = dto.Capacidad,
                EstadoBus = dto.EstadoBus
            };

            ViewBag.Estados = Enum.GetValues(typeof(EstadoBus))
              .Cast<EstadoBus>()
              .Select(e => new SelectListItem
              {
                  Value = e.ToString(),
                  Text = e.ToString()
              });

            ViewBag.Id = id;

            return View(editar);
        }

        // POST: Bus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateBusDto bus)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Id = id;
                    return View(bus);
                }

                var resultado = await _busService.UpdateAsync(id, bus);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    ViewBag.Id = id;
                    return View(bus);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(BusinessRuleException ex) 
            {
                ViewBag.Error = ex.Message;
                ViewBag.Id = id;
                return View(bus);
            }
        }

        // GET: Bus/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var bus = await _busService.GetByIdAsync(id);

            if (!bus.Success)
            {
                ViewBag.Error = bus.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(bus.Data);
        }

        // POST: Bus/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var resultado = await _busService.DeleteAsync(id);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}