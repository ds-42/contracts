using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Contracts.Domain.Enums;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Users.Domain;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler;

public class EmployeeAddCommand : IRequest<EmployeeView>
{
    public int OrgId { get; set; }
    public required string Surname { get; init; }
    public required string Name { get; init; }
    public required string Patronymic { get; init; }
    public string? PostName { get; init; }
    public string? Operating { get; init; }
    public string? PhoneWork { get; init; }
    public string? PhoneMobile { get; init; }
    public string? WWW { get; init; }
    public string? EMail { get; init; }
    public int UserId { get; init; }
    public EmployeeRole Role { get; init; }
    public Employee Map() => new Employee()
    {
        Id = 0,
        OrgId = OrgId,
        Surname = Surname,
        Name = Name,
        Patronymic = Patronymic,
        PostName = PostName ?? "",
        Operating = Operating,
        PhoneWork = PhoneWork,
        PhoneMobile = PhoneMobile,
        WWW = WWW,
        EMail = EMail,
        UserId = UserId,
        Role = Role,
    };
}

public class EmployeeAddHandler(
    IBaseWriteRepository<Employee> employes,
    IBaseReadRepository<OrgAdmin> orgs,
    IBaseReadRepository<User> users,
    ICurrentUserService user,
    EmployeeMemoryCache cache,
    IMapper _mapper) : IRequestHandler<EmployeeAddCommand, EmployeeView>
{
    public async Task<EmployeeView> Handle(EmployeeAddCommand command, CancellationToken cancellationToken)
    {
        await users.GetItem(command.UserId, cancellationToken);
        orgs.GetOrg(command.OrgId, user.Id);

        var employee = await employes.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.OrgId == command.OrgId && t.UserId == command.UserId, cancellationToken);

        if (employee != null)
            throw new CustomException("Duplicated employee");

        employee = await employes.AddAsync(command.Map(), cancellationToken);

        cache.Clear();

        return _mapper.Map<EmployeeView>(employee);
    }
}

public class EmployeeAddValidator : EmployeeValidator<EmployeeAddCommand>
{
    public EmployeeAddValidator()
    {
        RuleForId(e => e.UserId);
    }
}