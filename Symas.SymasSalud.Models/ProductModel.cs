using System;

namespace Symas.SymasSalud.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
    }
}
