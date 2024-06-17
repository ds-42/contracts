using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using MediatR;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

public class GetFormatsQueryHandler(
    IBaseReadRepository<Format> formats,
    FormatMemoryCache cache,
    IMapper mapper) : PaginatedQueryHandler<Format, GetFormatsQuery, FormatExDto>(formats, mapper, cache)
{
    protected override Expression<Func<Format, bool>>? Filter(GetFormatsQuery query)
    {
        return t => t.OrgId == query.OrgId;
    }

    protected override FormatExDto MapRecord(Format model)
    {
        var result = base.MapRecord(model);
        result.FormatType = model.FormatType.Name;
        return result;
    }

}