using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.ContractDocHandler.Queries.GetContractsвDocs;

public class GetContractDocsQueryHandler(
        IBaseReadRepository<Document> documents,
        СontractorService contractor,
        DocumentCache cache,
        IMapper mapper) : PaginatedQueryHandler<Document, GetContractDocsQuery, DocumentDto>(documents, mapper, cache)
{

    protected override async Task TestDataAccessAsync(GetContractDocsQuery query, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);
    }

    protected override async Task<Expression<Func<Document, bool>>?> FilterAsync(GetContractDocsQuery query, CancellationToken cancellationToken)
    {
        var contract = await contractor.GetContractAsync(query.ContractId, cancellationToken);

        return t => t.Group == contract.DocumentsGroup;
    }

    protected override Expression<Func<Document, object>> SortBy(GetContractDocsQuery query)
    {
        return t => t.RegistryDate;
    }
}
