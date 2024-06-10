using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.OwnershipHandler.Queries.GetOwnership;

public class GetOwnershipsQuery : BasePagination, IRequest<CountableList<OwnershipDto>>
{
}

