using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Services.Interface
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email, string password);
    }
}
