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
    public string Operating { get; set; } = default!;
    public string PhoneWork { get; set; } = default!;
    public string PhoneMobile { get; set; } = default!;
    public string WWW { get; set; } = default!;
    public string EMail { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public EmployeeRole Role { get; set; }
}
