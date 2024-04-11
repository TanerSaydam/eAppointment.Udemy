using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace eAppointmentServer.Infrastructure.Services;
internal sealed class JwtProvider(
    IConfiguration configuration,
    IUserRoleRepository userRoleRepository,
    RoleManager<AppRole> roleManager) : IJwtProvider
{
    public async Task<string> CreateTokenAsync(AppUser user)
    {
        List<AppUserRole> appUserRoles = await userRoleRepository.Where(p => p.UserId == user.Id).ToListAsync();

        List<AppRole> roles = new();

        foreach (var userRole in appUserRoles)
        {
            AppRole? role = await roleManager.Roles.Where(p => p.Id == userRole.RoleId).FirstOrDefaultAsync();
            if(role is not null)
            {
                roles.Add(role);
            }
        }

        List<string?> stringRoles = roles.Select(s => s.Name).ToList();

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim("UserName", user.UserName ?? string.Empty),
            new Claim(ClaimTypes.Role, JsonSerializer.Serialize(stringRoles))
        };

        DateTime expires = DateTime.Now.AddDays(1);

        SymmetricSecurityKey securityKey = 
            new(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecretKey").Value ?? ""));
        SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha512);

        JwtSecurityToken securityToken = new(
            issuer: configuration.GetSection("Jwt:Issuer").Value,
            audience: configuration.GetSection("Jwt:Audience").Value,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(securityToken);

        return token;
    }
}
