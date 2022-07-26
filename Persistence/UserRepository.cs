using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels.Users;

namespace Persistence
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _databaseContext;

        private IConfiguration _configuration;

        public UserRepository(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;

            _configuration = configuration;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _databaseContext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _databaseContext.Users
                        .Where(x => x.Id == id)
                        .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> GetUserByUserName(string username)
        {
            var user = await _databaseContext.Users
            .Where(x => x.UserName.ToLower() == username.ToLower())
            .FirstOrDefaultAsync();

            return user;
        }

        public async Task<LoginResponseViewModel> Login(LoginRequestViewModel viewModel)
        {
            if (viewModel == null)
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(viewModel.UserName))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(viewModel.Password))
            {
                return null;
            }

            var user = await _databaseContext.Users
                        .Where(u => u.UserName.ToLower() == viewModel.UserName.ToLower())
                        .FirstOrDefaultAsync();

            if(user == null)
            {
                return null;
            }

            if (string.Compare(user.Password, viewModel.Password, ignoreCase: false) != 0)
            {
                return null;
            }

            string secretKey = _configuration.GetValue<string>("ApplicationSettings:SecretKey");

            string token = JwtUtility.GenerateJwtToken(user, secretKey);

            LoginResponseViewModel response = new LoginResponseViewModel(user, token);

            return response;
        }
    }
}
