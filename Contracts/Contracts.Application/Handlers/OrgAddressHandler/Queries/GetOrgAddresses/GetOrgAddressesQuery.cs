using Contracts.Application.Handlers.AddressHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.OrgAddressHandler.Queries.GetOrgAddresses;

public class GetOrgAddressesQuery : BasePagination, IRequest<CountableList<AddressDto>>;
