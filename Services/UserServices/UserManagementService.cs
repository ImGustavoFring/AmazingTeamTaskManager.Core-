using AmazingTeamTaskManager.Core.DTOs.UserManagementDTOs;
using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.UserModel;
using AmazingTeamTaskManager.Core.Repositories.UserDbRepositories;
using AmazingTeamTaskManager.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Services.UserServices
{
    public class UserManagementService
    {
        private readonly UserRepository _userRepository;
        private readonly ProfileRepository _profileRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserManagementService(UserRepository userRepository, ProfileRepository profileRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserDTO> GetOneByIdAsync(Guid id)
        {
            try
            {
                var user = await _userRepository.GetOneAsync(u => u.Id == id);
                return ToUserDto(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get user by id: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            try
            {
                var users = await _userRepository.GetManyAsync(u => true);
                var userDtos = users.Select(user => ToUserDto(user)).ToList();
                return userDtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get users: {ex.Message}", ex);
            }
        }

        public async Task ChangeLoginAsync(Guid id, string newLogin)
        {
            try
            {
                await _userRepository.UpdateOneAsync(u => u.Id == id, user =>
                {
                    user.Login = newLogin;
                    user.UpdatedAt = DateTime.UtcNow;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to change login: {ex.Message}", ex);
            }
        }

        public async Task ChangePasswordAsync(Guid id, string newPassword)
        {
            try
            {
                var newPasswordHash = _passwordHasher.HashPassword(newPassword);
                await _userRepository.UpdateOneAsync(u => u.Id == id, user =>
                {
                    user.PasswordHash = newPasswordHash;
                    user.UpdatedAt = DateTime.UtcNow;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to change password: {ex.Message}", ex);
            }
        }

        public async Task ChangeEmailAsync(Guid id, string newEmail)
        {
            try
            {
                await _userRepository.UpdateOneAsync(u => u.Id == id, user =>
                {
                    user.Email = newEmail;
                    user.UpdatedAt = DateTime.UtcNow;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to change email: {ex.Message}", ex);
            }
        }

        public async Task ChangeFirstNameAsync(Guid userId, string newFirstName)
        {
            try
            {
                await _profileRepository.UpdateOneAsync(p => p.UserId == userId, profile =>
                {
                    profile.FirstName = newFirstName;
                    profile.UpdatedAt = DateTime.UtcNow;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to change first name: {ex.Message}", ex);
            }
        }

        public async Task ChangeLastNameAsync(Guid userId, string newLastName)
        {
            try
            {
                await _profileRepository.UpdateOneAsync(p => p.UserId == userId, profile =>
                {
                    profile.LastName = newLastName;
                    profile.UpdatedAt = DateTime.UtcNow;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to change last name: {ex.Message}", ex);
            }
        }

        public async Task ChangeDescriptionAsync(Guid userId, string newDescription)
        {
            try
            {
                await _profileRepository.UpdateOneAsync(p => p.UserId == userId, profile =>
                {
                    profile.Description = newDescription;
                    profile.UpdatedAt = DateTime.UtcNow;
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to change description: {ex.Message}", ex);
            }
        }

        public async Task DeleteOneAsync(Guid id)
        {
            try
            {
                await _userRepository.DeleteOneAsync(u => u.Id == id);
                await _profileRepository.DeleteOneAsync(p => p.UserId == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete user and profile: {ex.Message}", ex);
            }
        }

        private UserDTO ToUserDto(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                RoleInSystem = user.RoleInSystem.ToString(),
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
