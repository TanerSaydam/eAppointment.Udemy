using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Patients.GetAllPatient;
public sealed record GetAllPatientsQuery(): IRequest<Result<List<Patient>>>;