using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Berg8.Core.Security.Models;

namespace Berg8.Core.Security
{
    public interface IAuthenticationManager
    {
        IEnumerable<AuthenticationDescription> GetExternalAuthenticationTypes();

        ExternalLoginInfo GetExternalLoginInfo();
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();

        void SignIn(params ClaimsIdentity[] identities);

        void SignOut(params string[] authenticationTypes);
    }
}
