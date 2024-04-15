using AutoMapper;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.DTOs;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace Core.Application.Handlers.Quaries;

public abstract class PaginatedQueryHandler<T, TRequest, TModelResponse> : CachedQueryHandler<TRequest, CountableList<TModelResponse>>
    where TRequest : BasePagination, IRequest<CountableList<TModelResponse>> 
    where T : class, new()
    where TModelResponse : class, new()
{
    protected readonly IBaseReadRepository<T> _source;
    protected readonly IMapper _mapper;

    public PaginatedQueryHandler(IBaseReadRepository<T> source, IMapper mapper, MemoryCache cache, int cacheSize) : base(cache, cacheSize)
    {
        _source = source;
        _mapper = mapper;
    }

    protected virtual Expression<Func<T, bool>> Filter(TRequest query)
    {
        return t => true;
    }

    protected virtual Expression<Func<T, object>> SortBy(TRequest query)
    {
        return t => "";
    }

    protected override async Task<CountableList<TModelResponse>> ExecQuery(TRequest query, CancellationToken cancellationToken)
    {
        var filter = Filter(query);
        var items = await _source.AsAsyncRead().GetListAsync(
            offset: query.Offset,
            limit: query.Limit,
            predicate: filter,
            orderBy: SortBy(query),
            destinct: query.Descending,
            cancellationToken: cancellationToken);

        return new CountableList<TModelResponse>()
        {
            Count = await _source.AsAsyncRead().CountAsync(filter, cancellationToken),
            Items = _mapper.Map<IReadOnlyCollection<TModelResponse>>(items),
        };
    }

}