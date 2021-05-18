using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Symas.SymasSalud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symas.SymasSalud.Repositories.SqlServer
{
    public class CatalogsRepository:ICatalogsRepository
    {
        private readonly IMapper _mapper;
        private readonly SymasSaludDbContext _context;

        public CatalogsRepository(IMapper mapper,SymasSaludDbContext context) 
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<CatalogModel>> GetCaregoriesAsync()
        {
            var result = await _context.Categories.Where(c=>c.StatusId==true).ToListAsync();

            return _mapper.Map<List<CatalogModel>>(result);
        }
    }
}
