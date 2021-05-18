using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Symas.Core.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symas.Core.Repository.EntityFramework
{
    public class BaseRepositoryEntityFramework<TModel, TEntity, TContext> : IRepository<TModel>
    where TEntity : class
    where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly IMapper Mapper;
        //protected readonly IMqlTransformer Transformer;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //protected HttpContext HttpContext => _httpContextAccessor.HttpContext;
        //protected AuthenticatedUserModel User => _httpContextAccessor.HttpContext.User?.Current();

        public BaseRepositoryEntityFramework(
            TContext context,
            IMapper mapper
            //,IMqlTransformer transformer
            //,IHttpContextAccessor httpContextAccessor
            )
        {
            Context = context;
            Mapper = mapper;
            //Transformer = transformer;
            //_httpContextAccessor = httpContextAccessor;
        }

        //public virtual async Task<MqlQueryResult<TModel>> QueryMqlAsync(string query)
        //{
        //    var model = MQL.Compile(query);
        //    var entity = Transformer.Transform(model);
        //    var queryable = IncludeEagerLoads(Context.Set<TEntity>(), typeof(TEntity), entity);
        //    var entities = await queryable.ToEntity(entity).ToListAsync();

        //    var result = new MqlQueryResult<TModel>()
        //    {
        //        Values = entities.Select(c => Mapper.Map<TModel>(c.Value)).ToList(),
        //        TotalCount = entities.FirstOrDefault()?.TotalRecords
        //    };

        //    return result;
        //}


        public virtual async Task<TModel> CreateAsync(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return Mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> FindByIdAsync(params object[] id)
        {
            var entity = await Context.FindAsync<TEntity>(id);
            return Mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> UpdateAsync(TModel model, params object[] id)
        {
            var entity = await Context.FindAsync<TEntity>(id);
            Mapper.Map(model, entity);
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return Mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> UpdateAsync(TModel model)
        {
            var entity = Mapper.Map<TEntity>(model);
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return Mapper.Map<TModel>(entity);
        }

        public virtual async Task DeleteAsync(TModel model)
        {
            Context.Remove(Mapper.Map<TEntity>(model));
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(params object[] id)
        {
            var entity = await Context.FindAsync<TEntity>(id);
            if (entity != null)
            {
                Context.Remove(entity);
                await Context.SaveChangesAsync();
            }
        }

        public virtual async Task<ICollection<TModel>> FindByModelAsync(TModel model)
        {
            model.RequireThat().NotNull();

            var entity = Mapper.Map<TEntity>(model);

            var result = await Context
                           .Set<TEntity>()
                           .ToListAsync();

            return Mapper.Map<ICollection<TModel>>(result);
        }
        //private IQueryable<TEntity> IncludeEagerLoads(IQueryable<TEntity> queryable, Type baseType, MqlQuery query, string path = "")
        //{
        //    var entity = Context.Model.FindEntityType(baseType);
        //    if (entity != null)
        //    {
        //        entity.GetNavigations().ToList().ForEach(prop =>
        //        {
        //            var includePath = BuildIncludePath(path, prop);
        //            if (QueryIncludesPath(query, includePath) || ShouldEagerLoad(prop))
        //            {
        //                if (!QueryIncludesPath(query, includePath))
        //                {
        //                    queryable = queryable.Include(includePath);
        //                }

        //                queryable = IncludeEagerLoads(queryable, prop.GetTargetType().ClrType, query, includePath);
        //            }
        //        });
        //    }
        //    return queryable;
        //}

        private bool ShouldEagerLoad(INavigation prop) => prop.PropertyInfo.CustomAttributes.Any(x => x.AttributeType == typeof(EagerLoadAttribute));
        private string BuildIncludePath(string basePath, INavigation prop) => string.IsNullOrWhiteSpace(basePath) ? prop.Name : $"{basePath}.{prop.Name}";
        //private bool QueryIncludesPath(MqlQuery query, string path) => query.Includes.Any(x => x.ModelName == path);

    }
}
