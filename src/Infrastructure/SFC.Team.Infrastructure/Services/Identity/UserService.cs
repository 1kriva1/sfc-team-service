using Microsoft.AspNetCore.Http;

using SFC.Team.Application.Interfaces.Identity;
using SFC.Team.Infrastructure.Extensions;

namespace SFC.Team.Infrastructure.Services.Identity;
public class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId() => _httpContextAccessor.GetUserId();
}