namespace Contracts.Domain;

public class Format
{
    public int Id { get; set; }
    public int OrgId { get; set; }
    public string Name { get; set; } = default!;
    public int FormatTypeId { get; set; }

    public FormatType FormatType { get; set; } = default!;
    // навигационные поля для организации
}
