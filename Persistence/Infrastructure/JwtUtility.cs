using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Infrastructure
{
    public static class JwtUtility
    {
        static JwtUtility()
        {

        }

        public static string GenerateJwtToken(User user, string secretKey)
        {
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            var symmetricSecurityKey = new SymmetricSecurityKey(key);

            var securityAlgorithm = SecurityAlgorithms.HmacSha256Signature;

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, securityAlgorithm);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(type: ClaimTypes.NameIdentifier, value: user.Id.ToString()),
                    new Claim(type: ClaimTypes.Name, value: user.UserName)
                }),

                Expires = DateTime.UtcNow.AddMinutes(20),

                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor: tokenDescriptor);

            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        public static async Task AddUserToContext(HttpContext context, IUserRepository userRepository, string token, string secretKey)
        {
            try
            {
                byte[]? key = Encoding.ASCII.GetBytes(secretKey);

                var tokenHandler = new JwtSecurityTokenHandler();

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero,
                }, out SecurityToken validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                if(jwtToken == null)
                {
                    return;
                }

                Claim userIdClaim = jwtToken.Claims
                                        .Where(c => c.Type.ToLower() == "NameId".ToLower())
                                        .FirstOrDefault();

                if(userIdClaim == null)
                {
                    return;
                }

                var userId = int.Parse(userIdClaim.Value);

                User user = await userRepository.GetUserById(userId);

                // If User has deleted or deactivate
                if(user == null)
                {
                    return;
                }

                await Task.Run(() =>
                {
                    context.Items["User"] = user;
                });
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
