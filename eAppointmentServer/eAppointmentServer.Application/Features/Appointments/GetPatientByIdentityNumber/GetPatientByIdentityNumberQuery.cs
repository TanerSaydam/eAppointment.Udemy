using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.GetPatientByIdentityNumber;
public sealed record GetPatientByIdentityNumberQuery(
    string IdentityNumber) : IRequest<Result<Patient>>;
