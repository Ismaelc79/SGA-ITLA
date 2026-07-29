using Microsoft.AspNetCore.Mvc;

namespace SGA.Web.App.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
