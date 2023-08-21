using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMarket.Models
{
    [Table("tblArticle")]
    public class Article
    {
        
        [Column("id")]
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        
        [Column("code")]
        public string? Code { get ; set; }
        
        [Column("description")]
        public string? Description { get ; set ; }
        
        [Column("price")]
        public decimal Price { get; set; }
        
        [Column("stock")]
        public int Stock { get; set; }
    }
}
