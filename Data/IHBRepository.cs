using System.Collections.Generic;
using System.Threading.Tasks;
using HummingBoxApp.API.Dtos;
using HummingBoxApp.API.Models;

namespace HummingBoxApp.API.Data
{
    public interface IHBRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Item>> GetItems();
        Task<User> GetUser(int id);
        Task<IEnumerable<OrderDetail>> GetOrderDetails(int id);
        Task<IEnumerable<Order>> GetOrders(int id);
        Task<IEnumerable<HistoryListDto>> GetUserHistory(int id);
    }
}