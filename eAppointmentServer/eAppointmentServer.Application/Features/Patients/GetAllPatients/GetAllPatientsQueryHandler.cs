using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.GetAllPatient;

internal sealed class GetAllPatientsQueryHandler(
    IPatientRepository patientRepository) : IRequestHandler<GetAllPatientsQuery, Result<List<Patient>>>
{
    public async Task<Result<List<Patient>>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
    {
        List<Patient> patients = 
            await patientRepository
            .GetAll()
            .OrderBy(p => p.FirstName)
            .ToListAsync(cancellationToken);

        return patients;
    }
}
