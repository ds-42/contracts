using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.FormatTypeHandler.Queries.GetFormatTypes;

public class GetFormatTypesQuery : BasePagination, IRequest<CountableList<FormatTypeDto>>
{
}

