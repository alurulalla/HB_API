using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HummingBoxApp.API.Dtos;
using HummingBoxApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HummingBoxApp.API.Data
{
    public class HBRepository : IHBRepository
    {
        private readonly DataContext _context;

        public HBRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var items = await _context.Items.Include(i => i.ItemType).ToListAsync();

            return items;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<Order>> GetOrders(int id)
        {
            var orders = await _context.Orders.Include(o => o.UserId == id).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails(int id)
        {
            var orderDetails = await _context.OrderDetails.Include(o => o.OrderId == id).ToListAsync();
            return orderDetails;
        }

        public async Task<IEnumerable<HistoryListDto>> GetUserHistory(int id)
        {
            var data = await (from orderDetails in _context.OrderDetails
                              join order in _context.Orders
                              on orderDetails.OrderId equals order.Id
                              where order.UserId == id
                              select new ReturnHistoryItemDto
                              {
                                  ItemName = orderDetails.Item.Name,
                                  OrderId = orderDetails.OrderId,
                                  ItemId = orderDetails.ItemId,
                                  Quantity = orderDetails.Quantity,
                                  UnitPrice = orderDetails.UnitPrice,
                                  QuantityPrice = orderDetails.QuantityPrice,
                                  ItemType = orderDetails.Item.ItemType.Name,
                                  ItemTypeId = orderDetails.Item.ItemTypeId
                              }).ToListAsync();

            var historyData = await (from order in _context.Orders
                                     where order.UserId == id
                                     select new HistoryListDto
                                     {
                                         userId = order.UserId,
                                         price = order.Price,
                                         created = order.Created,
                                         orderId = order.Id,
                                         items = data.FindAll(o => o.OrderId == order.Id).ToList()
                                     }).OrderByDescending(o => o.created).ToListAsync();
            return historyData;
        }
    }
}