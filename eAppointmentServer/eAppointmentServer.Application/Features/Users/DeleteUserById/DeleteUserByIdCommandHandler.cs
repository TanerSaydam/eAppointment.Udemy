using eAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TS.Result;

namespace eAppointmentServer.Application.Features.Users.DeleteUserById;

internal sealed class DeleteUserByIdCommandHandler(
    UserManager<AppUser> userManager) : IRequestHandler<DeleteUserByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.FindByIdAsync(request.Id.ToString());
        if (appUser is null)
        {
            return Result<string>.Failure("User not found");
        }

        IdentityResult result = await userManager.DeleteAsync(appUser);
        if (!result.Succeeded)
        {
            return Result<string>.Failure(result.Errors.Select(s => s.Description).ToList());
        }

        return "User delete is successful";
    }
}
