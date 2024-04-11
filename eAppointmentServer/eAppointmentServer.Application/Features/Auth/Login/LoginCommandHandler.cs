using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(
    UserManager<AppUser> userManager,
    IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = 
            await userManager.Users.FirstOrDefaultAsync(p=> 
            p.UserName == request.UserNameOrEmail || 
            p.Email == request.UserNameOrEmail, cancellationToken);

        if (appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User not found");
        }

        bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser, request.Password);
        if (!isPasswordCorrect)
        {
            return Result<LoginCommandResponse>.Failure("Password is wrong");
        }

        string token = await jwtProvider.CreateTokenAsync(appUser);
        LoginCommandResponse response = new(token);

        return Result<LoginCommandResponse>.Succeed(response);
    }
}
