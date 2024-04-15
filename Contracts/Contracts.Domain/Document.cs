namespace Contracts.Domain;

public class Document
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public string Number { get; set; } = default!;
    public DateTime RegistryDate { get; set; }
    public string Title { get; set; } = default!;
    public int FileId { get; set; } = default!;

    public File File { get; set; } = default!;
}
