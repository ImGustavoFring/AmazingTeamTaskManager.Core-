using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.UserModel;
using AmazingTeamTaskManager.Core.Repositories.UserDbRepositories;
using AmazingTeamTaskManager.Core.Infrastructure;
using System;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;
        private readonly ProfileRepository _profileRepository;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(
            UserRepository userRepository,
            ProfileRepository profileRepository,
            IJwtGenerator jwtGenerator,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _profileRepository = profileRepository;
            _jwtGenerator = jwtGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> RegisterAsync(string login,
            string email, string password,
            string firstName, string lastName)
        {
            try
            {
                var existingUser = await _userRepository.GetOneAsync(u => u.Login == login || u.Email == email);
                if (existingUser != null)
                {
                    throw new Exception("User with the same login or email already exists.");
                }

                var hashedPassword = _passwordHasher.HashPassword(password);

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Login = login,
                    Email = email,
                    PasswordHash = hashedPassword,
                    RoleInSystem = RoleInSystem.USER,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _userRepository.AddOneAsync(user);

                var profile = new Profile
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    FirstName = firstName,
                    LastName = lastName,
                    Description = string.Empty,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _profileRepository.AddOneAsync(profile);

                return _jwtGenerator.GenerateToken(user.Id, user.RoleInSystem.ToString(), user.Login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to register user: {ex.Message}", ex);
            }
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            try
            {
                var user = await _userRepository.GetOneAsync(u => u.Login == login);
                if (user == null || !_passwordHasher.VerifyPassword(password, user.PasswordHash))
                {
                    throw new Exception("Invalid login or password.");
                }

                return _jwtGenerator.GenerateToken(user.Id, user.RoleInSystem.ToString(), user.Login);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to login: {ex.Message}", ex);
            }
        }
    }
}
