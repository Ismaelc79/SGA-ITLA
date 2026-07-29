using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.DTOs.Horario;
using SGA.Application.Interfaces.Trips;
using SGA.Domain.Enums;

namespace SGA.Web.App.Controllers
{
    public class HorarioController : Controller
    {
        private readonly IHorarioService _horarioService;

        public HorarioController(IHorarioService horarioService)
        {
            _horarioService = horarioService;
        }

        // GET: Horario
        public async Task<IActionResult> Index()
        {
            var horario = await _horarioService.GetAllAsync();

            if (!horario.Success)
            {
                ViewBag.Error = horario.Message;
                return View(new List<HorarioDto>());
            }

            IEnumerable<HorarioDto> resultado = horario.Data!;
                      
            ViewBag.Horario = horario;

            return View(resultado.ToList());
        }

        // GET: Horario/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var horario = await _horarioService.GetByIdAsync(id);

            if (!horario.Success)
            {
                ViewBag.Error = horario.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(horario.Data);
        }

        // GET: Horario/Create
        public IActionResult Create()
        {
            ViewBag.DiasOperacion = Enum.GetValues(typeof(DiasOperacion))
             .Cast<DiasOperacion>()
             .Select(e => new SelectListItem
             {
                 Value = e.ToString(),
                 Text = e.ToString()
             });

            return View(new CreateHorarioDto());
        }

        // POST: Horario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateHorarioDto horario)
        {
            try
            {
             
                if (!ModelState.IsValid)
                {
                    return View(horario);
                }
              
                var resultado = await _horarioService.CreateAsync(horario);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    return View(horario);
                }
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View(horario);
            }
        }

        // GET: Horario/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var horario = await _horarioService.GetByIdAsync(id);

            if (!horario.Success)
            {
                ViewBag.Error = horario.Message;
                return RedirectToAction(nameof(Index));
            }

            var dto = horario.Data!;

            var editar = new UpdateHorarioDto
            {
                RutaId = dto.RutaId,
                DiasOperacion = dto.DiasOperacion,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
            };

            ViewBag.DiasOperacion = Enum.GetValues(typeof(DiasOperacion))
              .Cast<DiasOperacion>()
              .Select(e => new SelectListItem
              {
                  Value = e.ToString(),
                  Text = e.ToString()
              });

            ViewBag.Id = id;

            return View(editar);
        }

        // POST: Horario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateHorarioDto horario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Id = id;
                    return View(horario);
                }

                var resultado = await _horarioService.UpdateAsync(id, horario);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    ViewBag.Id = id;
                    return View(horario);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Id = id;
                return View(horario);
            }
        }

        // GET: Horario/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var horario = await _horarioService.GetByIdAsync(id);

            if (!horario.Success)
            {
                ViewBag.Error = horario.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(horario.Data);
        }

        // POST: Horario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var resultado = await _horarioService.DeleteAsync(id);

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