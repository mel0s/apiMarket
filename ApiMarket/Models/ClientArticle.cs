using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMarket.Models
{
    [Table("tblClientArticle")]
    public class ClientArticle
    {

        private DateTime dateUpdate = DateTime.Now;


        [SwaggerSchema(ReadOnly = true)]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("id_client")]        
        public int? ClientId { get; set; }
        
        [Column("id_article")]        
        public int? ArticleId{ get; set; }

        [Column("date_update")]
        [DataType(DataType.DateTime)]
        public DateTime DateUpdate { get => dateUpdate; set => dateUpdate = value; }

        [SwaggerSchema(ReadOnly = true)]
        //[ForeignKey("ClientId")]
        public virtual  Client? Client { get; set; } = null!;

        [SwaggerSchema(ReadOnly = true)]
        //[ForeignKey("ArticleId")]
        public virtual  Article? Article { get; set; } = null!;



    }
}
