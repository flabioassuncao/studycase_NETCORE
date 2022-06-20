using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace BSC.WebApi.Core.User;

public interface IAspNetUser
{
    string Name { get; }
    Guid GetUserId();      
    string GetUserEmail(); 
    string GetUserToken();
    string GetUserRefreshToken();
    bool IsAuthenticated();
    bool HasRole(string role);
    IEnumerable<Claim> GetClaims();
    HttpContext GetHttpContext();
}