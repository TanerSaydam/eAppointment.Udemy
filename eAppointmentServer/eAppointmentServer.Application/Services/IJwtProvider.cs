using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Application.Services;
public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user);
}
