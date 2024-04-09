using eAppointmentServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eAppointmentServer.Infrastructure.Configurations;
internal sealed class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasKey(k => new { k.UserId, k.RoleId });
    }
}
