using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.GetAllDoctorByDepartment;

internal sealed class GetAllDoctorsByDepartmentQueryHandler(
    IDoctorRepository doctorRepository) : IRequestHandler<GetAllDoctorsByDepartmentQuery, Result<List<Doctor>>>
{
    public async Task<Result<List<Doctor>>> Handle(GetAllDoctorsByDepartmentQuery request, CancellationToken cancellationToken)
    {
        List<Doctor> doctors = 
            await doctorRepository
            .Where(p => p.Department == request.DepartmentValue)
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);

        return doctors;
    }
}
