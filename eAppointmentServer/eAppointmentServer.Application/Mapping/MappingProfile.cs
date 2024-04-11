using AutoMapper;
using eAppointmentServer.Application.Features.Doctors.CreateDoctor;
using eAppointmentServer.Application.Features.Doctors.UpdateDoctor;
using eAppointmentServer.Application.Features.Patients.CreatePatient;
using eAppointmentServer.Application.Features.Patients.UpdatePatient;
using eAppointmentServer.Application.Features.Users.CreateUser;
using eAppointmentServer.Application.Features.Users.UpdateUser;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace eAppointmentServer.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        });

        CreateMap<UpdateDoctorCommand, Doctor>().ForMember(member => member.Department, options =>
        {
            options.MapFrom(map => DepartmentEnum.FromValue(map.DepartmentValue));
        });

        CreateMap<CreatePatientCommand, Patient>();
        CreateMap<UpdatePatientCommand, Patient>();

        CreateMap<CreateUserCommand, AppUser>();
        CreateMap<UpdateUserCommand, AppUser>();
    }
}
