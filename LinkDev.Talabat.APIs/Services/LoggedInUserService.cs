using LinkDev.Talabat.Core.Application.Abstraction;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LinkDev.Talabat.APIs.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string? UserId { get; private set; }

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;


            UserId = _httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.PrimarySid);
        }
    }
}
