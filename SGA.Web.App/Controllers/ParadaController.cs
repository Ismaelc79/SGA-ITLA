using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.DTOs.Parada;
using SGA.Application.DTOs.Ruta;
using SGA.Application.Interfaces.Trips;
using SGA.Application.Exceptions;

namespace SGA.Web.App.Controllers
{
    public class ParadaController : Controller
    {
        private readonly IParadaService _paradaService;

        public ParadaController(IParadaService paradaService)
        {
            _paradaService = paradaService;
        }

        // GET: Parada
        public async Task<IActionResult> Index()
        {
            var parada = await _paradaService.GetAllAsync();

            if (!parada.Success)
            {
                ViewBag.Error = parada.Message;
                return View(new List<ParadaDto>());
            }

            IEnumerable<ParadaDto> resultado = parada.Data!;

            ViewBag.Ruta = parada;

            return View(resultado.ToList());
        }

        // GET: Parada/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var parada = await _paradaService.GetByIdAsync(id);

            if (!parada.Success)
            {
                ViewBag.Error = parada.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(parada.Data);
        }

        // GET: Parada/Create
        public IActionResult Create()
        {
            return View(new CreateParadaDto());
        }

        // POST: Parada/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateParadaDto parada)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(parada);
                }

                var resultado = await _paradaService.CreateAsync(parada);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    return View(parada);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ViewBag.Error = ex.Message;
                return View(parada);
            }
        }

        // GET: Parada/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var parada = await _paradaService.GetByIdAsync(id);

            if (!parada.Success)
            {
                ViewBag.Error = parada.Message;
                return RedirectToAction(nameof(Index));
            }

            var dto = parada.Data!;

            var editar = new UpdateParadaDto
            {
                Id = dto.Id,
                RutaId = dto.RutaId,
                Nombre = dto.Nombre,
                Ubicacion = dto.Ubicacion,
                OrdenParada = dto.OrdenParada,
                Estado = dto.Estado
            };
                        
            ViewBag.Id = id;

            return View(editar);
        }

        // POST: Parada/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateParadaDto parada)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Id = id;
                    return View(parada);
                }

                var resultado = await _paradaService.UpdateAsync(id, parada);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    ViewBag.Id = id;
                    return View(parada);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message;
                ViewBag.Id = id;
                return View(parada);
            }
        }

        // GET: Parada/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var parada = await _paradaService.GetByIdAsync(id);

            if (!parada.Success)
            {
                ViewBag.Error = parada.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(parada.Data);
        }

        // POST: Parada/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var resultado = await _paradaService.DeleteAsync(id);

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