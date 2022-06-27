using onlineStore.Application.Paging;
using onlineStore.Core.Entities;

namespace onlineStore.Application.IServices
{
    public interface IItemsService
    {
        Task<PagedList<Item>> GetItemsPageAsync(PageParameters pageParameters);
        Task<PagedList<Item>> GetItemsPageAsync(PageParameters pageParameters, string filter);
        Task<Item> GetItemAsync(int id);
    }
}