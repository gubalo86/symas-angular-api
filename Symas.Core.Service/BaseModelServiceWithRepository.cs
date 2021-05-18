using Microsoft.AspNetCore.Http;
using Symas.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Symas.Core.Service
{
    public abstract class BaseModelServiceWithRepository<TRepository, TModel> :
        IModelService<TModel>
        where TRepository : IRepository<TModel>
        where TModel : class, new()
    {
        protected TRepository Repository { get; }
        //private readonly IHttpContextAccessor _httpContextAccessor;
        //protected HttpContext HttpContext => _httpContextAccessor.HttpContext;
        //protected AuthenticatedUserModel User => _httpContextAccessor.HttpContext.User?.Current();

        public BaseModelServiceWithRepository(
            TRepository repository
            //, IHttpContextAccessor httpContextAccessor
            )
        {
            Repository = repository;
            //_httpContextAccessor = httpContextAccessor;
        }

        //public virtual async Task<ServiceResult<MqlQueryResult<TModel>>> QueryMqlAsync(string query)
        //{
        //    try
        //    {
        //        var result = await Repository.QueryMqlAsync(query);

        //        if (result == null)
        //            return ServiceResult<MqlQueryResult<TModel>>.Failure();

        //        return ServiceResult<MqlQueryResult<TModel>>.Success(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ServiceResult<MqlQueryResult<TModel>>.Failure(ex);
        //    }
        //}

        public virtual async Task<ServiceResult<TModel>> CreateAsync(TModel model)
        {
            try
            {
                var result = await Repository.CreateAsync(model);

                if (result == null)
                    return ServiceResult<TModel>.Failure();

                return ServiceResult<TModel>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.Failure(ex);
            }

        }

        public virtual async Task<ServiceResult<TModel>> UpdateAsync(TModel model)
        {
            try
            {
                var result = await Repository.UpdateAsync(model);

                if (result == null)
                    return ServiceResult<TModel>.Failure();

                return ServiceResult<TModel>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.Failure(ex);
            }

        }

        public virtual async Task<ServiceResult<TModel>> DeleteAsync(TModel model)
        {
            try
            {
                await Repository.DeleteAsync(model);

                return ServiceResult<TModel>.Success(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.Failure(ex);
            }
        }

        public virtual async Task<ServiceResult<TModel>> DeleteAsync(params object[] id)
        {
            try
            {
                await Repository.DeleteAsync(id);

                return ServiceResult<TModel>.Success();
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.Failure(ex);
            }
        }

        public virtual async Task<ServiceResult<TModel>> FindByIdAsync(params object[] id)
        {
            try
            {
                var result = await Repository.FindByIdAsync(id);

                if (result == null)
                    return ServiceResult<TModel>.NotFound();

                return ServiceResult<TModel>.Success(result);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.Failure(ex);
            }
        }

    }
}
