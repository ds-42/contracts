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
    IBaseReadRepository<OrgAdmin> orgs,
    IBaseReadRepository<User> users,
    ICurrentUserService user,
    EmployeeMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
{
    public async Task<EmployeeDto> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        await users.TestExists(command.UserId, cancellationToken);
        await orgs.TestAccess(command.OrgId, user.Id, cancellationToken);

        var employee = await employes.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == command.OrgId && t.UserId == command.UserId, cancellationToken);

        if (employee != null)
            throw new CustomException("Duplicated employee");

        employee = await employes.AddAsync(command.Map(), cancellationToken);

        cache.Clear();

        return _mapper.Map<EmployeeDto>(employee);
    }
}