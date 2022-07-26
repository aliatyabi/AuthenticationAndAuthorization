using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Infrastructure.Middlewares
{
    public class JwtMiddleware
    {
        protected RequestDelegate Next { get; }

        protected IConfiguration Configuration { get; }

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Next = next;

            Configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUserRepository userRepository)
        {
            var requestHeaders = context.Request.Headers["Authorization"];

            string? token = requestHeaders.FirstOrDefault()?.Split(' ').Last();

            string secretKey = Configuration.GetValue<string>("ApplicationSettings:SecretKey");

            if (string.IsNullOrWhiteSpace(token) == false)
            {
                await JwtUtility.AddUserToContext(context, userRepository, token, secretKey);
            }

            await Next(context);
        }
    }
}
