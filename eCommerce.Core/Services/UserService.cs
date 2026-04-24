using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services
{
    internal class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<AuthenticationResponse?> Login(LoginRequest request)
        {
            ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(
                request.Email,
                request.Password
            );

            if (user is null)
            {
                return null;
            }

            var userResponse = _mapper.Map<AuthenticationResponse>(user);
            return userResponse;
        }

        public async Task<AuthenticationResponse?> RegisterUser(RegisterRequest request)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            ApplicationUser? registerResponse = await _userRepository.AddUser(user);

            if (registerResponse is null)
            {
                return null;
            }

            var userResponse = _mapper.Map<AuthenticationResponse>(registerResponse) with
            {
                Success = true,
                Token = "dummy-token-for-now",
            };
            return userResponse;
        }
    }
}
