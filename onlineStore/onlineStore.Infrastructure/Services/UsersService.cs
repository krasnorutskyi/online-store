using System.Security.Claims;
using onlineStore.Application.Descriptions;
using onlineStore.Application.DTOs;
using onlineStore.Application.IServices;
using onlineStore.Core.Entities;
using onlineStore.Application.IRepositories;

namespace onlineStore.Infrastructure.Services
{
    public class UsersService : IUsersService
    {
        private readonly IGenericRepository<User> _usersRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UsersService(IGenericRepository<User> usersRepository, IPasswordHasher passwordHasher)
        {
            this._passwordHasher = passwordHasher;
            this._usersRepository = usersRepository;
        }

        public async Task<OperationDetails> RegisterAsync(UserDTO userDTO)
        {
            var operationDetails = new OperationDetails();
            if ((await this._usersRepository.GetAllAsync(u => u.Email == userDTO.Email)).Any())
            {
                operationDetails.AddError("This email is already used!");
                return operationDetails;
            }

            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
            };
            
            try
            {
                user.PasswordHash = this._passwordHasher.Hash(userDTO.Password);
                this._usersRepository.Attach(user);
                await this._usersRepository.AddAsync(user);
            }
            catch (Exception e)
            {
                operationDetails.AddError(e.Message);
            }

            return operationDetails;
        }

        public async Task<OperationDetails> LoginAsync(UserDTO userDTO)
        {
            var user = await this.GetAsync(userDTO.Email);

            var operationDetails = new OperationDetails();
            if (user == null)
            {
                operationDetails.AddError("User with this email not found!");
                return operationDetails;
            }

            if (!this._passwordHasher.Check(userDTO.Password, user.PasswordHash))
            {
                operationDetails.AddError("Incorrect password!");
            }

            return operationDetails;
        }

        public async Task UpdateAsync(User user)
        {
            this._usersRepository.Attach(user);
            await this._usersRepository.UpdateAsync(user);
        }
        
        public async Task<User?> GetAsync(string email)
        {
            var user = await this._usersRepository.GetAllAsync(u => u.Email == email, 
                u => u.UserToken);
            return user.FirstOrDefault();
        }

        public async Task DeleteAsync(User user)
        {
            await this._usersRepository.DeleteAsync(user);
        }
    }
}