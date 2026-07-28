using Microsoft.EntityFrameworkCore.Update.Internal;

namespace SGA.Application.Validators.Common
{
    public static class ValidationMessages
    {
        public static string Requerido(string campo)
            => $"{campo} es obligatorio";

        public static string LongitudMaxima(string campo, int maximo)
            => $"{campo} no puede exceder los {maximo} caracteres.";

        public static string LongitudMinima(string campo, int minimo)
            => $"{campo} debe tener al menos {minimo} carácter(es).";

        public static string MayorACero(string campo)
            => $"{campo} debe tener un mayor valor a cero.";

        public static string EnumInvalido(string campo)
            => $"{campo} contiene un valor no reconocido por el sistema.";

        public static string EnumRequerido(string campo)
            => $"Debe seleccionar un estado válido para {campo}";
    }
}
