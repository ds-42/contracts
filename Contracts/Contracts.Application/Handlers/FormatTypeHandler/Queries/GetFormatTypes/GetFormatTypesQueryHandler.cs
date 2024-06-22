using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;

namespace Contracts.Application.Handlers.FormatTypeHandler.Queries.GetFormatTypes;

public class GetFormatTypesQueryHandler(
    IBaseReadRepository<FormatType> formatTypes,
    FormatTypeCache cache,
    IMapper mapper) : PaginatedQueryHandler<FormatType, GetFormatTypesQuery, FormatTypeDto>(formatTypes, mapper, cache)
{

}