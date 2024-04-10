using eAppointmentServer.Domain.Enums;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.CreateDoctor;
public sealed record CreateDoctorCommand(
    string FirstName,
    string LastName,
    int Department) : IRequest<Result<string>>;
