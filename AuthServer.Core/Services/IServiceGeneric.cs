using SharedLibrary.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IServiceGeneric<T,TDto> where T:class where TDto:class
    {

        Task<Response<TDto>> GetByIdAsync(int id);

        Task<Response<IEnumerable<TDto>>> GetAllAsync();

        Task<Response<IEnumerable<TDto>>> WhereAsync(Expression<Func<T, bool>> predicate);

        Task<Response<TDto>> AddAsync(TDto entity);

        Task<Response<NoDataDTO>> RemoveAsync(int id);

        Task<Response<NoDataDTO>> UpdateAsync(TDto entiy,int id);

    }
}
