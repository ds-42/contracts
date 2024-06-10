using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.FileHandler;

public class FileDto : IMapFrom<Domain.File>
{
    public int Id { get; set; }
}
