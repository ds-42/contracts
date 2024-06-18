using Contracts.Application.Handlers.OrgHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.PartnerHandler.Queries.GetPartners;

public class GetPartnersQuery : BasePagination, IRequest<CountableList<PartnerDto>>
{
}
