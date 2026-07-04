
using SGA.Domain.Base;

namespace SGA.Application.Base
{
    public interface  IBaseService<TDto, TCreateDto,TUpdateDto>
        where TDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        Task<OperationResult<IEnumerable<TDto>>> GetAllAsync();
        Task<OperationResult<TDto>> GetByIdAsync(int id);
        Task<OperationResult<TDto>> CreateAsync(TCreateDto dto);
        Task<OperationResult<TDto>> UpdateAsync(int id, TUpdateDto dto);
        Task<OperationResult<bool>> DeleteAsync(int id);
       
    }
}
