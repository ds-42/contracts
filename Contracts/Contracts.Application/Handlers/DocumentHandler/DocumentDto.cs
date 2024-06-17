using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.DocumentHandler;

public class DocumentDto : IMapFrom<Document>
{
    public int Id { get; set; }
    public string Number { get; set; } = default!;
    public DateOnly RegistryDate { get; set; }
    public string Title { get; set; } = default!;
}
