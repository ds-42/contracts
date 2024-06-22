using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.FormatHandler;
using Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.UpdateEmployee;

public class UpdateEmployeeCommandHandler(
    IBaseWriteRepository<Employee> employees,
    IBaseReadRepository<OrgAdmin> admins,
    ICurrentUserService user,
    EmployeeCache cache,
    IMapper mapper) : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(user.OrgId, user.Id, cancellationToken);

        var employee = await employees.GetItem(user.OrgId, command.UserId, cancellationToken);

        mapper.Map(command, employee);

        await employees.UpdateAsync(employee, cancellationToken);

        cache.Clear();

        return mapper.Map<EmployeeDto>(employee);
    }
}