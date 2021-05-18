using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Symas.Core.Repository
{
    public interface IRepository<TModel>
    {
        //public Task<MqlQueryResult<TModel>> QueryMqlAsync(string query);

        Task<TModel> CreateAsync(TModel model);

        Task<TModel> UpdateAsync(TModel model, params object[] id);

        Task<TModel> UpdateAsync(TModel model);

        Task DeleteAsync(TModel model);

        Task DeleteAsync(params object[] id);

        Task<TModel> FindByIdAsync(params object[] id);

        Task<ICollection<TModel>> FindByModelAsync(TModel model);
    }
}
