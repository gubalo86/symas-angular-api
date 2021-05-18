using Symas.Core.Service;
using Symas.SymasSalud.Interfaces;
using Symas.SymasSalud.Models;
using Symas.SymasSalud.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Symas.SymasSalud.Services
{
    public class ProductService: BaseModelServiceWithRepository<IProductRepository, ProductModel>, IProductService
    {
        public ProductService(
            IProductRepository repository) :base(repository)
        { }

        public async Task<ServiceResult<List<ProductModel>>> GetAllAsync()
        {
            try {
                var result = await Repository.GetAllAsync();

                return ServiceResult<List<ProductModel>>.Success(result);
            }
            catch (Exception e) {
                return ServiceResult<List<ProductModel>>.Failure(e);
            }
        }
    }
}
