using onlineStore.Core.Entities;

namespace onlineStore.Application.IServices;

public interface IOrdersService
{
    void Add(Order order, Item item);
    
    void Delete(Order order, Item item);

    void ConfirmOrder(Order order);
}