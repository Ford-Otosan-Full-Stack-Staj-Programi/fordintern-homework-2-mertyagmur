using FordInternHW2.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Service.Base.Abstract
{
    public interface IBaseService<Dto, TEntity>
    {
        Task<BaseResponse<Dto>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync();
        Task<BaseResponse<bool>> PostAsync(Dto insertResource);
        Task<BaseResponse<bool>> Put(int id, Dto updateResource);
        Task<BaseResponse<bool>> Delete(int id);
        BaseResponse<List<Dto>> Where(Expression<Func<TEntity, bool>> where);
    }
}
