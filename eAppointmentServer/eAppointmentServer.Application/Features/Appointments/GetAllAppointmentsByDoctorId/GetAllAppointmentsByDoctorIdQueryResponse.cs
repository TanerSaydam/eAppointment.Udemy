using eAppointmentServer.Domain.Entities;

namespace eAppointmentServer.Application.Features.Appointments.GetAllAppointments;

public sealed record GetAllAppointmentsByDoctorIdQueryResponse(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    string Title,
    Patient Patient);
