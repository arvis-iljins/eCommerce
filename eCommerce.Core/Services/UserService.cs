using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<AuthenticationResponse?> Login(LoginRequest request)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(
                request.Email,
                request.Password
            );

            if (user == null)
            {
                return null;
            }

            var userResponse = new AuthenticationResponse(
                user.Id,
                user.Email,
                user.PersonName,
                user.Gender,
                "token",
                Success: true
            );
            return userResponse;
        }

        public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest request)
        {
            ApplicationUser? user = new()
            {
                Email = request.Email,
                Password = request.Password,
                PersonName = request.PersonName,
                Gender = request.Gender.ToString(),
            };
            ApplicationUser? registerResponse = await _userRepository.AddUser(user);

            if (registerResponse == null)
            {
                return null;
            }
            var userResponse = new AuthenticationResponse(
                registerResponse.Id,
                registerResponse.Email,
                registerResponse.PersonName,
                registerResponse.Gender,
                "token",
                Success: true
            );

            return userResponse;
        }
    }
}
