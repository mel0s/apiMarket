using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMarket.Models
{
    [Table("tblStore")]
    public class Store
    {
        [Column("id")]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        [Column("subsidiary")]
        public string? Subsidiary { get; set; }
        [Column("address")]
        public string? Address { get; set; }
    }
}
