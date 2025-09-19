using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClientService _clientService;
        public AuthService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public Client? Login(string email, string password)
        {
            var client = _clientService.GetAll().FirstOrDefault(c => c._emailAddress == email);

            if (client == null)
                return null;

                if (PasswordHelper.VerifyPassword(password, client._password))
                    return client;
            
            return null;
        }
    }
}
