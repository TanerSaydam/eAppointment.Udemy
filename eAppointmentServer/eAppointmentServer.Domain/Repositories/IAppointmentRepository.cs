using eAppointmentServer.Domain.Entities;
using GenericRepository;

namespace eAppointmentServer.Domain.Repositories;

public interface IAppointmentRepository : IRepository<Appointment>
{
}