using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Infrastructure.ApplicationSettings
{
    public class AppSettings
    {
        public AppSettings()
        {

        }

        public string? SecretKey { get; set; }

        public int TokenExpires { get; set; }
    }
}
