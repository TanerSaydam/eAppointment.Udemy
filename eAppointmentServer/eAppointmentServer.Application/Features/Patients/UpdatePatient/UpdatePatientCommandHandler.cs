using AutoMapper;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.UpdatePatient;

internal sealed class UpdatePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await patientRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (patient is null)
        {
            return Result<string>.Failure("Patient not found");
        }

        if(patient.IdentityNumber != request.IdentityNumber)
        {
            if(patientRepository.Any(p=> p.IdentityNumber == request.IdentityNumber))
            {
                return Result<string>.Failure("This identity number already use");
            }
        }

        mapper.Map(request, patient);

        patientRepository.Update(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Patient update is successful";
    }
}
