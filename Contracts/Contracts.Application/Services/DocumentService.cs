using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;
using Contracts.Application.Handlers.DocumentHandler.Commands.DeleteDocument;
using Contracts.Application.Handlers.DocumentHandler.Commands.UpdateDocument;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Microsoft.Extensions.Configuration;

namespace Contracts.Application.Services;

public class DocumentInfo
{
    public string FilePath { get; set; } = default!;
    public string FileName { get; set; } = default!;
}

public class DocumentService(
    IBaseWriteRepository<Domain.Document> documents,
    ICurrentUserService user,
    IBaseReadRepository<Domain.File> files,
    IConfiguration configuration,
    DocumentCache cache,
    IMapper _mapper)
{
    public async Task<Domain.Document> GetDocumentAsync(int id, CancellationToken cancellationToken)
    {
        return await documents.AsAsyncRead()
            .SingleAsync(t => t.Id == id, cancellationToken);
    }

    public async Task<DocumentDto> CreateDocumentAsync(CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        var file = await files.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == command.FileId && t.UserId == user.Id, cancellationToken);

        if (file == null)
            throw new AccessDeniedException();

        var doc = await documents.AddAsync(command.Map(), cancellationToken);

        if (doc.Group == 0)
        {
            doc.Group = doc.Id;
            await documents.UpdateAsync(doc, cancellationToken);
            command.Group = doc.Id;
        }

        cache.Clear();

        return _mapper.Map<DocumentDto>(doc);
    }

    public async Task<DocumentDto> UpdateDocumentAsync(UpdateDocumentCommand command, CancellationToken cancellationToken)
    {
        var doc = await documents.GetItem(command.Group, command.Id, cancellationToken);

        _mapper.Map(command, doc);

        await documents.UpdateAsync(doc, cancellationToken);

        cache.Clear();

        return _mapper.Map<DocumentDto>(doc);
    }

    public async Task<bool> DeleteDocumentAsync(DeleteDocumentCommand command, CancellationToken cancellationToken)
    {
        var doc = await documents.GetItem(command.Group, command.Id, cancellationToken);

        await documents.RemoveAsync(doc, cancellationToken);

        cache.Clear();

        return true;
    }

    public async Task<DocumentInfo> GetInfoAsync(Domain.Document doc, CancellationToken cancellationToken)
    {
        var file = await files.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == doc.FileId, cancellationToken);

        if (file == null)
            throw new AccessDeniedException();

        var sourcePath = configuration["Files"];

        return new DocumentInfo()
        {
            FilePath = $"{sourcePath}{file.Id}",
            FileName = file.FileName,
        };
    }
}
