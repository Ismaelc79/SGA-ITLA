using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGA.Application.DTOs.Ticket;
using SGA.Application.Interfaces.Configuration;
using SGA.Domain.Enums;
using SGA.Application.Exceptions;

namespace SGA.Web.App.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            var ticket = await _ticketService.GetAllAsync();

            if (!ticket.Success)
            {
                ViewBag.Error = ticket.Message;
                return View(new List<TicketDto>());
            }

            IEnumerable<TicketDto> resultado = ticket.Data!;

            ViewBag.Ticket = ticket;

            return View(resultado.ToList());
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (!ticket.Success)
            {
                ViewBag.Error = ticket.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(ticket.Data);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            ViewBag.Estados = Enum.GetValues(typeof(EstadoTicket))
               .Cast<EstadoTicket>()
               .Select(e => new SelectListItem
               {
                   Value = e.ToString(),
                   Text = e.ToString()
               });

            return View(new CreateTicketDto());
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTicketDto ticket)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ticket);
                }

                var resultado = await _ticketService.CreateAsync(ticket);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    return View(ticket);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(BusinessRuleException ex) 
            {   
                ViewBag.Error = ex.Message;
                return View(ticket);
            }
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (!ticket.Success)
            {
                ViewBag.Error = ticket.Message;
                return RedirectToAction(nameof(Index));
            }

            var dto = ticket.Data!;

            var editar = new UpdateTicketDto
            {
                Id = dto.Id,
                EstudianteId = dto.EstudianteId,
                RutaId = dto.RutaId,
                ParadaId = dto.ParadaId,
                PagoId = dto.PagoId,
                Tipo = dto.Tipo,
                EstadoTicket = dto.EstadoTicket,
                FechaInicio = dto.FechaInicio,
                FechaCierre = dto.FechaCierre
            };

            ViewBag.Estados = Enum.GetValues(typeof(EstadoTicket))
                .Cast<EstadoTicket>()
                .Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                });

            ViewBag.Id = id;

            return View(editar);
        }

        // POST: Ticket/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateTicketDto ticket)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Id = id;
                    return View(ticket);
                }

                var resultado = await _ticketService.UpdateAsync(id, ticket);

                if (!resultado.Success)
                {
                    ViewBag.Error = resultado.Message;
                    ViewBag.Id = id;
                    return View(ticket);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(BusinessRuleException ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Id = id;
                return View(ticket);
            }
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);

            if (!ticket.Success)
            {
                ViewBag.Error = ticket.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(ticket.Data);
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var resultado = await _ticketService.DeleteAsync(id);

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