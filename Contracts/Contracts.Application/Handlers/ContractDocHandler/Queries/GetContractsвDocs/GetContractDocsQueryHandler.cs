using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Services;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Auth.Application.Abstractions.Service;
using System.Linq.Expressions;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts.Application.Handlers.ContractDocHandler.Queries.GetContractsвDocs;

public class GetContractDocsQueryHandler(
        IBaseReadRepository<Document> documents,
        СontractorService contractor,
        ICurrentUserService user,
        DocumentMemoryCache cache,
        IMapper mapper) : PaginatedQueryHandler<Document, GetContractDocsQuery, DocumentDto>(documents, mapper, cache)
{

    protected override async Task TestDataAccessAsync(GetContractDocsQuery query, CancellationToken cancellationToken)
    {
        await contractor.TestContractAccess(query.ContractId, cancellationToken);
    }

    protected override async Task<Expression<Func<Document, bool>>?> FilterAsync(GetContractDocsQuery query, CancellationToken cancellationToken)
    {
        var group = await contractor.GetContractDocumentGroupAsync(query.ContractId, cancellationToken);

        return t => t.GroupId == group;
    }

    protected override Expression<Func<Document, object>> SortBy(GetContractDocsQuery query)
    {
        return t => t.RegistryDate;
    }
}
