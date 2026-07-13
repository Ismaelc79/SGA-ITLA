

namespace SGA.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string entidad, object id)
            : base($"{entidad} con identificador '{id}' no fue encontrado.")
        {
        }
    }
}
