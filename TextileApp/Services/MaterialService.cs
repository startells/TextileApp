using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TextileApp.Data;
using TextileApp.Data.Entities;

namespace TextileApp.Services
{
    public interface IMaterialService
    {
        Task<int> GetMaterialCountAsync();
        Task<List<Material>> GetMaterialsAsync();
        Task<int> GetTotalStockAsync();
    }

    public class MaterialService : IMaterialService
    {
        private readonly TextileDbContext _dbContext;

        public MaterialService(TextileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetMaterialCountAsync()
        {
            return await _dbContext.Materials.CountAsync();
        }

        public async Task<List<Material>> GetMaterialsAsync()
        {
            return await _dbContext.Materials.ToListAsync();
        }

        public async Task<int> GetTotalStockAsync()
        {
            return await _dbContext.Materials.SumAsync(m => m.StockQuantity);
        }
    }
}
