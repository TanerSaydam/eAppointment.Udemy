using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace eAppointmentServer.Application.Features.Users.GetAllUsers;
public sealed record GetAllUsersQuery() : IRequest<Result<List<GetAllUsersQueryResponse>>>;
