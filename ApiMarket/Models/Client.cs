using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMarket.Models
{
    [Table("tblClient")]
    public class Client
    {


        [Column("id" )]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get ; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("last_name")]
        public string? LastName { get; set; }

        [Column("address")]
        public string? Address { get; set; }
        
    }
}
