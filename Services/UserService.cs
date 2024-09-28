using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;
using Microsoft.AspNetCore.Identity;

namespace LocaFilms.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AspNetUserManager<UserModel> _userManager;

        public UserService(IUserRepository userRepository, AspNetUserManager<UserModel> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserModel?> GetUserByIdAsync(string id)
        {   
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<UserResponse> UpdateUserAsync(string id, UserModel user)
        {
            UserModel? userToUpdate = await GetUserByIdAsync(id);
            
            if (userToUpdate == null)
                return new UserResponse($"O usuário com id {id} não existe.");

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.PhoneNumber = user.PhoneNumber;

            try
            {
                var result = await _userManager.UpdateAsync(userToUpdate);
                
                if (!result.Succeeded)
                    return new UserResponse($"Não foi possível atualizar o usuário (id = {id}). Erro: {result.Errors.Select(e => e.Description).First()}");

                return new UserResponse(userToUpdate);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Não foi possível atualizar o usuário (id = {id}). Erro: {ex.Message}");
            }
        }

        public async Task<UserResponse> DeleteUserAsync(string id)
        {
            var userToDelete = await GetUserByIdAsync(id);

            if (userToDelete == null)
                return new UserResponse($"O usuário com id {id} não existe.");

            try
            {
                await _userManager.DeleteAsync(userToDelete);
                return new UserResponse(userToDelete);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Houve um erro ao tentar deletar o usuário (id = {id}). Erro: {ex.Message}");
            }
        }
    }
}
