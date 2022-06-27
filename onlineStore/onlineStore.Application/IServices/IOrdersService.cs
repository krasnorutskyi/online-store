using onlineStore.Core.Entities;

namespace onlineStore.Application.IServices;

public interface IOrdersService
{
    Task AddAsync(Item item);
    
    Task DeleteAsync(Item item);

    Task ConfirmAsync(Order order);
}