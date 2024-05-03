using Contracts.Domain.Enums;

namespace Contracts.Domain;

public class Employee
{
    public int Id { get; set; }
    public int OrgId { get; set; }
    public string Surname { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Patronymic { get; set; } = default!;
    public string PostName { get; set; } = default!;
    public string? Operating { get; set; }
    public string? PhoneWork { get; set; }
    public string? PhoneMobile { get; set; }
    public string? WWW { get; set; }
    public string? EMail { get; set; }
    public int UserId { get; set; }
    public EmployeeRole Role { get; set; }
}
