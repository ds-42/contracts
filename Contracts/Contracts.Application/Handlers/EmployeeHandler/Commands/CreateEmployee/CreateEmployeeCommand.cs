using Contracts.Domain;
using Contracts.Domain.Enums;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.CreateEmployee;

public class CreateEmployeeCommand : IRequest<EmployeeDto>
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
    public Employee Map() => new()
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

