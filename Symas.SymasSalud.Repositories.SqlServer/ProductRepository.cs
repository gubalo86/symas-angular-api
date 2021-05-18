using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Symas.Core.Repository.EntityFramework;
using Symas.SymasSalud.Models;
using Symas.SymasSalud.Repositories.SqlServer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Symas.SymasSalud.Repositories.SqlServer
{
    public class ProductRepository: BaseRepositoryEntityFramework<ProductModel, ProductEntity, SymasSaludDbContext>,
        IProductRepository
    {
        public ProductRepository(
            SymasSaludDbContext context,
            IMapper mapper):base(context,mapper) 
        { }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            var result =await Context.Products.ToListAsync();

            return Mapper.Map<List<ProductModel>>(result);
        }
    }
}
