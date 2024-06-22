using Contracts.Domain;
using Contracts.Domain.Enums;
using Core.Application.Abstractions.Mappings;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.UpdateEmployee;

public class UpdateEmployeeCommand : IMapTo<Employee>, IRequest<EmployeeDto>
{
    public int UserId { get; set; }
    public required string Surname { get; init; }
    public required string Name { get; init; }
    public required string Patronymic { get; init; }
    public string? PostName { get; init; }
    public string? Operating { get; init; }
    public string? PhoneWork { get; init; }
    public string? PhoneMobile { get; init; }
    public string? WWW { get; init; }
    public string? EMail { get; init; }
    public EmployeeRole Role { get; init; }
}


