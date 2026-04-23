using eCommerce.Core.Entities;
using eCommerce.Core.Enums;
using eCommerce.Core.RepositoryContracts.UserRepository;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.Id = Guid.NewGuid();
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(
            string? email,
            string? password
        )
        {
            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                PersonName = "John Doe",
                Gender = GenderOptions.Male.ToString(),
            };

            return user;
        }
    }
}
