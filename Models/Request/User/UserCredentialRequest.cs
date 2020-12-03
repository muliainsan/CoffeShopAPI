using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeShop.Models.Request.User
{
    public class UserCredentialRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
