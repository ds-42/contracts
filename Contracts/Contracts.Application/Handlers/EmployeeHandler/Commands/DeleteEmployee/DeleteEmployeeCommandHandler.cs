using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.DeleteEmployee;

public class DeleteEmployeeCommandHandler(
    IBaseWriteRepository<Employee> employees,
    IBaseReadRepository<OrgAdmin> admins,
    ICurrentUserService user,
    FormatMemoryCache cache) : IRequestHandler<DeleteEmployeeCommand, bool>
{
    public async Task<bool> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        await admins.TestAccess(user.OrgId, user.Id, cancellationToken);

        var employee = await employees.GetItem(user.OrgId, command.Id, cancellationToken);

        await employees.RemoveAsync(employee, cancellationToken);

        cache.Clear();

        return true;
    }
}