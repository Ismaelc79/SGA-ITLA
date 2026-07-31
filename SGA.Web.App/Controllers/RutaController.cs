using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.DTOs.Ruta;
using SGA.Application.Interfaces.Trips;
using SGA.Domain.Enums;

namespace SGA.Web.App.Controllers
{
    public class RutaController : Controller
    {
        private readonly IRutaService _rutaService;

        public RutaController(IRutaService rutaService)
        {
            _rutaService = rutaService;
        }

        // GET: Ruta
        public async Task<IActionResult> Index()
        {
            var ruta = await _rutaService.GetAllAsync();

            if (!ruta.Success)
            {
                ViewBag.Error = ruta.Message;
                return View(new List<RutaDto>());
            }

            IEnumerable<RutaDto> resultado = ruta.Data!;

            ViewBag.Ruta = ruta;

            return View(resultado.ToList());
        }

        // GET: Ruta/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ruta = await _rutaService.GetByIdAsync(id);

            if (!ruta.Success)
            {
                ViewBag.Error = ruta.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(ruta.Data);
        }

        // GET: Ruta/Create
        public IActionResult Create()
        {
            return View(new CreateRutaDto());
        }

        // POST: Ruta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRutaDto ruta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ruta);
                }

                var resultado = await _rutaService.CreateAsync(ruta);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    return View(ruta);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ruta);
            }
        }

        // GET: Ruta/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ruta = await _rutaService.GetByIdAsync(id);

            if (!ruta.Success)
            {
                ViewBag.Error = ruta.Message;
                return RedirectToAction(nameof(Index));
            }

            var dto = ruta.Data!;

            var editar = new UpdateRutaDto
            {
               Id = dto.Id,
               Nombre = dto.Nombre,
               Descripcion = dto.Descripcion,
               EstadoRuta = dto.EstadoRuta,
               RutaOrigen = dto.RutaOrigen,
               RutaDestino = dto.RutaDestino
            };

            ViewBag.Estados = Enum.GetValues(typeof(EstadoRuta))
                .Cast<EstadoRuta>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                });

            ViewBag.Id = id;

            return View(editar);
        }

        // POST: Ruta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateRutaDto ruta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Id = id;
                    return View(ruta);
                }

                var resultado = await _rutaService.UpdateAsync(id, ruta);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    ViewBag.Id = id;
                    return View(ruta);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Id = id;
                return View(ruta);
            }
        }

        // GET: Ruta/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ruta = await _rutaService.GetByIdAsync(id);

            if (!ruta.Success)
            {
                ViewBag.Error = ruta.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(ruta.Data);
        }

        // POST: Ruta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var resultado = await _rutaService.DeleteAsync(id);

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