using ApiMarket.Models;

namespace ApiMarket.Service
{
    public interface IClientArticleService
    {
        Task<List<ClientArticle>> GetArticlesByIdClient(int idClient);

        Task<List<ClientArticleLabel>> GetArticlesByIdClientLabel(int idClient);

        Task<List<ListArticle>> GetListArticles();


        Task<List<ListClient>> GetListClients();

    }
}
