using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Users;

namespace Persistence
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);

        Task<User> GetUserByUserName(string username);

        Task<List<User>> GetAllUsers();

        Task<LoginResponseViewModel> Login(LoginRequestViewModel viewModel);
    }
}
