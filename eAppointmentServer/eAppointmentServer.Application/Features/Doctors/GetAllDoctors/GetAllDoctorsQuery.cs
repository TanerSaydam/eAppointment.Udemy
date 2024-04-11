using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Doctors.GetAllDoctor;
public sealed record GetAllDoctorsQuery() : IRequest<Result<List<Doctor>>>;
