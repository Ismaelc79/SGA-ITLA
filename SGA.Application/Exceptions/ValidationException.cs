
namespace SGA.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public IReadOnlyList<string> Errores { get; }
        public ValidationException(IEnumerable<string> errores)
            : base("Uno o más campos no son válidos.")
        {
            Errores = errores.ToList();
        }
    
    }
}
