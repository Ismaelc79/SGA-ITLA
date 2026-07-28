using SGA.Domain.Enums;

namespace SGA.Web.App.Models
{
    public class BusViewModel
    {
        public int Id { get; set; }
        public int ConductorId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }
        public EstadoBus EstadoBus { get; set; }
    }
}
