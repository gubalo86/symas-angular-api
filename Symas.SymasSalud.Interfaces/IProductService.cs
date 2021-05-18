using Symas.Core.Service;
using Symas.SymasSalud.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Symas.SymasSalud.Interfaces
{
    public interface IProductService : IModelService<ProductModel>
    {
        Task<ServiceResult<List<ProductModel>>> GetAllAsync();
    }
}
