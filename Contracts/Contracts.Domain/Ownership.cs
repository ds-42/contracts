using Contracts.Domain.Enums;

namespace Contracts.Domain;

public class Ownership
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public FormType Type { get; set; }
}
