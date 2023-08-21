using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMarket.Models
{
    [Table("tblStoreArticle")]
    public class StoreArticle
    {

        private DateTime dateUpdate = DateTime.Now;

        [SwaggerSchema(ReadOnly = true)]
        [Column("id")]
        public int Id { get; set; }

        [Column("id_store")]
        public int IdStore { get; set; }

        [Column("id_article")]
        public int IdArticle { get; set; }

        [Column("date_update")]
        [DataType(DataType.DateTime)]
        public DateTime DateUpdate { get => dateUpdate; set => dateUpdate = value; }
    }
}
