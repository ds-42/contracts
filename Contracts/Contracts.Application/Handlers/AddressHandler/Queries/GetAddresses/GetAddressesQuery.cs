using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.AddressHandler.Queries.GetAddresses;

public class GetAddressesQuery : BasePagination, IRequest<CountableList<AddressDto>>
{
    public int Group { get; set; }
}

