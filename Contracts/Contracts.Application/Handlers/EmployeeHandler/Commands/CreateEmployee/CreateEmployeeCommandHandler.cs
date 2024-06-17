using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Users.Domain;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.CreateEmployee;

public class CreateEmployeeCommandHandler(
    IBaseWriteRepository<Employee> employes,
    IBaseReadRepository<OrgAdmin> admins,
    ICurrentUserService user,
    EmployeeMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(user.OrgId, user.Id, cancellationToken);

        var employee = await employes.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == user.OrgId && t.UserId == command.UserId, cancellationToken);

        if (employee != null)
            throw new CustomException("Duplicated employee");

        employee = command.Map();
        employee.OrgId = user.OrgId; 
        employee = await employes.AddAsync(employee, cancellationToken);

        cache.Clear();

        return _mapper.Map<EmployeeDto>(employee);
    }
}