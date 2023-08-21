using ApiMarket.Data;
using ApiMarket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace ApiMarket.Service.Impl
{
    public class ClientArtcleServiceImpl : IClientArticleService
    {
        private readonly ApiMarketContext _context;

        public ClientArtcleServiceImpl(ApiMarketContext context)
        {
            _context = context;

        }

        public async Task<List<ListClient>> GetListClients()
        {
            DbSet<Client>? clientCtx = _context.Client;
            if (clientCtx == null)
            {

                return new List<ListClient>();
            }
            return await clientCtx.Select( x =>  new ListClient() { Id = x.Id, Value = x.Name + " " + x.LastName}  ).ToListAsync();
        }

        public async Task<List<ClientArticle>> GetArticlesByIdClient(int idClient)
        {

            DbSet<ClientArticle>? clientArticle = _context.ClientArticle;
            if (clientArticle == null)
            {

                return new List<ClientArticle>();
            }
            return await clientArticle.Where(item => item.ClientId == idClient).ToListAsync();
        }

        public async Task<List<ClientArticleLabel>> GetArticlesByIdClientLabel(int idClient)
        {
            DbSet<ClientArticle>? clientArticle = _context.ClientArticle;
            if (clientArticle == null)
            {

                return new List<ClientArticleLabel>();
            }

            var clientArticleList = await clientArticle
                 .Include(e => e.Client)
                 .Where(e => e.ClientId == idClient)
                 .OrderBy(e => e.ArticleId)
                 .ToListAsync();

            List<ClientArticleLabel> list = new List<ClientArticleLabel>();
            foreach (ClientArticle c in clientArticleList)
            {
                list.Add(new ClientArticleLabel()
                {
                    ArticleId = c.ArticleId,
                    ClientId = c.ClientId,
                    Id = c.Id,
                    ArticleLabel = c.Article?.Description,
                    ClientLabel =c.Client?.Name + " " + c.Client?.LastName
                });
            }
          
            return list;

        }

        public async Task<List<ListArticle>> GetListArticles()
        {
            DbSet<Article>? articleCtx = _context.Article;
            if (articleCtx == null)
            {

                return new List<ListArticle>();
            }
            return await articleCtx.Select(x => new ListArticle() { Id = x.Id, Value = x.Description }).ToListAsync();

        }
    }
}
