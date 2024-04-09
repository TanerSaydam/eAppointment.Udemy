using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Application.Services;
public interface IJwtProvider
{
    string CreateToken(AppUser user);
}
