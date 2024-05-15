using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.EmployeeHandler;

public class EmployeeDto : IMapFrom<Employee>
{
    public int Id { get; set; }
    public string Surname { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Patronymic { get; set; } = default!;
    public string? PostName { get; init; }
    public string? Operating { get; init; }
    public string? PhoneWork { get; init; }
    public string? PhoneMobile { get; init; }
    public string? WWW { get; init; }
    public string? EMail { get; init; }
}
