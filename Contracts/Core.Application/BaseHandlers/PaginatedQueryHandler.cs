using AutoMapper;
using Core.Application.Abstractions;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;
using System.Linq.Expressions;

namespace Core.Application.BaseHandlers;

public abstract class PaginatedQueryHandler<TModel, TRequest, TResult> : BaseCachedQuery<TRequest, CountableList<TResult>>
    where TRequest : BasePagination, IRequest<CountableList<TResult>> 
    where TModel : class, new()
    where TResult : class, new()
{
    protected readonly IBaseReadRepository<TModel> _source;
    protected readonly IMapper _mapper;

    public PaginatedQueryHandler(
        IBaseReadRepository<TModel> source, 
        IMapper mapper, 
        IBaseCache<CountableList<TResult>> cache) : base(cache)
    {
        _source = source;
        _mapper = mapper;
    }

    protected virtual Expression<Func<TModel, bool>> Filter(TRequest query)
    {
        return t => true;
    }

    protected virtual Expression<Func<TModel, object>> SortBy(TRequest query)
    {
        return t => "";
    }

    protected override async Task<CountableList<TResult>> ExecQuery(TRequest query, CancellationToken cancellationToken)
    {
        var filter = Filter(query);
        var items = await _source.AsAsyncRead().GetListAsync(
            offset: query.Offset,
            limit: query.Limit,
            predicate: filter,
            orderBy: SortBy(query),
            destinct: query.Descending,
            cancellationToken: cancellationToken);

        return new CountableList<TResult>()
        {
            Count = await _source.AsAsyncRead().CountAsync(filter, cancellationToken),
            Items = _mapper.Map<IReadOnlyCollection<TResult>>(items),
        };
    }

}