using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.DocumentHandler.Queries.GetDocuments;

public class GetDocumentsQueryHandler(
    IBaseReadRepository<Document> documents,
    DocumentMemoryCache cache,
    IMapper mapper) : PaginatedQueryHandler<Document, GetDocumentsQuery, DocumentDto>(documents, mapper, cache)
{
    protected override Expression<Func<Document, bool>>? Filter(GetDocumentsQuery query)
    {
        return t => t.Group == query.Group;
    }

}