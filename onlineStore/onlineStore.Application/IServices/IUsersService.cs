using onlineStore.Core.Entities;

namespace onlineStore.Application.IServices
{
    public interface IUsersService
    {
        Task<TokensModel> RegisterAsync(User user);

        Task<TokensModel> LoginAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);
    }
}