using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken( List<Claim> claims);

    }
}
