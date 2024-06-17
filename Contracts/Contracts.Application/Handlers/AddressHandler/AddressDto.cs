using Contracts.Domain;
using Core.Application.Abstractions.Mappings;

namespace Contracts.Application.Handlers.AddressHandler;

public class AddressDto : IMapFrom<Address>
{
    public int Id { get; set; }
    public string Note { get; set; } = default!;
}
