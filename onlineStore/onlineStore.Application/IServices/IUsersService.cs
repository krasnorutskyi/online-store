using onlineStore.Application.Descriptions;
using onlineStore.Application.DTOs;
using onlineStore.Core.Entities;

namespace onlineStore.Application.IServices
{
    public interface IUsersService
    {
        Task<OperationDetails> RegisterAsync(UserDTO userDTO);

        Task<OperationDetails> LoginAsync(UserDTO userDTO);
        
        Task<User?> GetAsync(string email);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);
    }
}