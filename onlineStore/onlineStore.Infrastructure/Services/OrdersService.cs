using onlineStore.Application.IRepositories;
using onlineStore.Application.IServices;
using onlineStore.Core.Entities;

namespace onlineStore.Infrastructure.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IGenericRepository<Order> _ordersRepository;

        public OrdersService(IGenericRepository<Order> ordersRepository)
        {
            this._ordersRepository = ordersRepository;
        }
        
        public void Add(Order order, Item item)
        {
            order.Items.Add(item);
        }

        public void Delete(Order order, Item item)
        {
            order.Items.Remove(item);
        }

        public async void ConfirmOrder(Order order)
        {
            await this._ordersRepository.AddAsync(order);
        }
    }
}