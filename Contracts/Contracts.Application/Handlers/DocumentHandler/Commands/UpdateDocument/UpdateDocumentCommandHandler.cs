using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.FormatHandler;
using Contracts.Application.Handlers.FormatHandler.Commands.UpdateFormat;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.DocumentHandler.Commands.UpdateDocument;

public class UpdateDocumentCommandHandler(
    IBaseWriteRepository<Document> documents,
    DocumentMemoryCache cache,
    IMapper _mapper) : IRequestHandler<UpdateDocumentCommand, DocumentDto>
{
    public async Task<DocumentDto> Handle(UpdateDocumentCommand command, CancellationToken cancellationToken)
    {
        var doc = await documents.GetItem(command.Group, command.Id, cancellationToken);

        _mapper.Map(command, doc);

        await documents.UpdateAsync(doc, cancellationToken);

        cache.Clear();

        return _mapper.Map<DocumentDto>(doc);
    }
}