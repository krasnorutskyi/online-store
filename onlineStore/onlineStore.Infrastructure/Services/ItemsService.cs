using onlineStore.Application.IRepositories;
using onlineStore.Application.IServices;
using onlineStore.Application.Paging;
using onlineStore.Core.Entities;

namespace onlineStore.Infrastructure.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IGenericRepository<Item> _itemsRepository;
        public ItemsService(IGenericRepository<Item> itemsRepository)
        {
            this._itemsRepository = itemsRepository;
        }
        
        public async Task<PagedList<Item>> GetItemsPageAsync(PageParameters pageParameters)
        {
            return await this._itemsRepository.GetPageAsync(pageParameters);
        }

        public async Task<PagedList<Item>> GetItemsPageAsync(PageParameters pageParameters, string filter)
        {
            return await this._itemsRepository.GetPageAsync(pageParameters, 
                item => item.Category.Name.Contains(filter));
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await this._itemsRepository.GetOneAsync(id);
        }
    }
}