using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Symas.SymasSalud.Repositories.SqlServer.Entities
{
    [Table("Product")]
    public class ProductEntity
    {
        [Key]
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
    }
}
