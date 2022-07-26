using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Infrastructure.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Users;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        public UsersController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        protected IUserRepository UserRepository { get; }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseViewModel>> Login(LoginRequestViewModel viewModel)
        {
            LoginResponseViewModel response = await UserRepository.Login(viewModel);

            if(response == null)
            {
                return BadRequest(new { message = "Invalid Username and/or password!" });
            }

            return Ok(response);
        }

        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await UserRepository.GetAllUsers();

            return Ok(users);
        }
    }
}
