
using SGA.Application.Base;
using SGA.Application.DTOs.Parada;

namespace SGA.Application.Interfaces.Configuration
{
    public interface IParadaService : 
        IBaseService<ParadaDto, CreateParadaDto, UpdateParadaDto>
    {

    }
}
