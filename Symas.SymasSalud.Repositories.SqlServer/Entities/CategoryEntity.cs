using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Symas.SymasSalud.Repositories.SqlServer.Entities
{
    [Table("Category")]
    public class CategoryEntity
    {
        [Key]
        public long Id { get; set; }
        public string Category { get; set; }
        public bool StatusId { get; set; }
    }
}
