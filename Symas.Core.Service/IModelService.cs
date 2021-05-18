using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Symas.Core.Service
{
    public interface IModelService<TModel> where TModel : class
    {
        //public Task<ServiceResult<MqlQueryResult<TModel>>> QueryMqlAsync(string query);

        Task<ServiceResult<TModel>> CreateAsync(TModel model);

        Task<ServiceResult<TModel>> UpdateAsync(TModel model);

        Task<ServiceResult<TModel>> DeleteAsync(TModel model);

        Task<ServiceResult<TModel>> DeleteAsync(params object[] id);

        Task<ServiceResult<TModel>> FindByIdAsync(params object[] id);

    }
}
