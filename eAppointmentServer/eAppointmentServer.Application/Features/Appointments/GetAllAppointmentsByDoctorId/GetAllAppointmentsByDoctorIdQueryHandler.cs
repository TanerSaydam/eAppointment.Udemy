using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Appointments.GetAllAppointments;

internal sealed class GetAllAppointmentsByDoctorIdQueryHandler(
    IAppointmentRepository appointmentRepository) : IRequestHandler<GetAllAppointmentsByDoctorIdQuery, Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>>
{
    public async Task<Result<List<GetAllAppointmentsByDoctorIdQueryResponse>>> Handle(GetAllAppointmentsByDoctorIdQuery request, CancellationToken cancellationToken)
    {
        List<Appointment> appointments = 
            await appointmentRepository
            .Where(p => p.DoctorId == request.DoctorId)
            .Include(p=> p.Patient)
            .ToListAsync(cancellationToken);


        List<GetAllAppointmentsByDoctorIdQueryResponse> response =
            appointments.Select(s => 
            new GetAllAppointmentsByDoctorIdQueryResponse(
                s.Id,
                s.StartDate, 
                s.EndDate, 
                s.Patient!.FullName,
                s.Patient))
            .ToList();

        return response;
    }
}
