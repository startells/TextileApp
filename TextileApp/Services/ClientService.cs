using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TextileApp.Data;
using TextileApp.Data.Entities;

namespace TextileApp.Services
{
    public interface IClientService
    {
        Task<int> GetClientCountAsync();
        Task<List<Client>> GetClientsAsync();
    }

    public class ClientService : IClientService
    {
        private readonly TextileDbContext _dbContext;

        public ClientService(TextileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetClientCountAsync()
        {
            return await _dbContext.Clients.CountAsync();
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }
    }
}
