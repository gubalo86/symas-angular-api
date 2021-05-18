using Symas.Core.Repository;
using Symas.SymasSalud.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Symas.SymasSalud.Repositories
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        Task<List<ProductModel>> GetAllAsync();
    }
}
