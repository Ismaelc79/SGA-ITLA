using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.DTOs.TarjetaRecargable;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Enums;

namespace SGA.Web.App.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly ITarjetaRecargableService _tarjetaService;

        public TarjetaController(ITarjetaRecargableService tarjetaService)
        {
            _tarjetaService = tarjetaService;
        }

        // GET: Tarjeta
        public async Task<IActionResult> Index()
        {
            var tarjeta = await _tarjetaService.GetAllAsync();

            if (!tarjeta.Success)
            {
                ViewBag.Error = tarjeta.Message;
                return View(new List<TarjetaRecargableDto>());
            }

            IEnumerable<TarjetaRecargableDto> resultado = tarjeta.Data!;

            ViewBag.Ticket = tarjeta;

            return View(resultado.ToList());
        }

        // GET: Tarjeta/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var tarjeta = await _tarjetaService.GetByIdAsync(id);

            if (!tarjeta.Success)
            {
                ViewBag.Error = tarjeta.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(tarjeta.Data);
        }

        // GET: Tarjeta/Create
        public IActionResult Create()
        {
            ViewBag.Estados = Enum.GetValues(typeof(EstadoTarjeta))
               .Cast<EstadoTarjeta>()
               .Select(e => new SelectListItem
               {
                   Value = e.ToString(),
                   Text = e.ToString()
               });

            return View(new CreateTarjetaRecargableDto());
        }

        // POST: Tarjeta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTarjetaRecargableDto tarjeta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(tarjeta);
                }

                var resultado = await _tarjetaService.CreateAsync(tarjeta);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    return View(tarjeta);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(tarjeta);
            }
        }

        // GET: Tarjeta/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var tarjeta = await _tarjetaService.GetByIdAsync(id);

            if (!tarjeta.Success)
            {
                ViewBag.Error = tarjeta.Message;
                return RedirectToAction(nameof(Index));
            }

            var dto = tarjeta.Data!;

            var editar = new UpdateTarjetaRecargableDto
            {
                Id = dto.Id,
                EstudianteId = dto.EstudianteId,
                PagoId = dto.PagoId,
                MontoTarjeta = dto.MontoTarjeta,
                EstadoTarjeta = dto.EstadoTarjeta,
                FechaVigenteInicio = dto.FechaVigenteInicio,
                FechaVigenteFin = dto.FechaVigenteFin
            };

            ViewBag.Estados = Enum.GetValues(typeof(EstadoTarjeta))
                .Cast<EstadoTarjeta>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                });

            ViewBag.Id = id;

            return View(editar);
        }

        // POST: Tarjeta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTarjetaRecargableDto tarjeta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Id = id;
                    return View(tarjeta);
                }

                var resultado = await _tarjetaService.UpdateAsync(id, tarjeta);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    ViewBag.Id = id;
                    return View(tarjeta);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Id = id;
                return View(tarjeta);
            }
        }

        // GET: Tarjeta/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var tarjeta = await _tarjetaService.GetByIdAsync(id);

            if (!tarjeta.Success)
            {
                ViewBag.Error = tarjeta.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(tarjeta.Data);
        }

        // POST: Tarjeta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var resultado = await _tarjetaService.DeleteAsync(id);

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