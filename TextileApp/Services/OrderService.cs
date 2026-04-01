using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TextileApp.Data;
using TextileApp.Data.Entities;

namespace TextileApp.Services
{
    public static class OrderStatus
    {
        public const string Active = "Active";
        public const string Completed = "Completed";
        public const string Cancelled = "Cancelled";
    }

    public interface IOrderService
    {
        Task<int> GetActiveOrderCountAsync();
        Task<List<Order>> GetActiveOrdersAsync();
        Task<List<Order>> GetOrdersAsync();
    }

    public class OrderService : IOrderService
    {
        private readonly TextileDbContext _dbContext;

        public OrderService(TextileDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetActiveOrderCountAsync()
        {
            return await _dbContext.Orders
                .Where(o => o.Status == OrderStatus.Active)
                .CountAsync();
        }

        public async Task<List<Order>> GetActiveOrdersAsync()
        {
            return await _dbContext.Orders
                .Where(o => o.Status == OrderStatus.Active)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }
    }
}
