using Symas.SymasSalud.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Symas.SymasSalud.Repositories
{
    public interface ICatalogsRepository
    {
        Task<List<CatalogModel>> GetCaregoriesAsync();
    }
}
