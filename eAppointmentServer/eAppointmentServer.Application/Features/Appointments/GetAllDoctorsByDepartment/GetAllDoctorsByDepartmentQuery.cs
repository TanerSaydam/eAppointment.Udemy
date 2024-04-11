using eAppointmentServer.Domain.Entities;
using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.GetAllDoctorByDepartment;
public sealed record GetAllDoctorsByDepartmentQuery(
    int DepartmentValue) : IRequest<Result<List<Doctor>>>;
