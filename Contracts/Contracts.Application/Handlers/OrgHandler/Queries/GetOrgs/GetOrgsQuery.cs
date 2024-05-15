using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Queries.GetOrgs;

public class GetOrgsQuery : BasePagination, IRequest<CountableList<OrgDto>>
{
}
