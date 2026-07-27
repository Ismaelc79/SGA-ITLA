

namespace SGA.Application.Validators.Common
{
    public static class ValidationConstants
    {
        public const int LongitudTextoCorta = 50;
        public const int LongitudTextoLarga = 200;
        public const string PatronPlaca = @"^[A-Z]{1,2}\d{5,6}$"; //Formato placas Dominicanas
    }
}
