using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Users
{
    public class LoginResponseViewModel
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Token { get; set; }

        public LoginResponseViewModel(User user, string token)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            Token = token;
            Id = user.Id;
            UserName = user.UserName;
        }
    }
}
