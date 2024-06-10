using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Handlers.DocumentHandler;
using Contracts.Application.Handlers.DocumentHandler.Commands.CreateDocument;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Commands.CreateFormat;

public class CreateDocumentCommandHandler(
    IBaseWriteRepository<Document> documents,
    IBaseReadRepository<Domain.File> files,
    ICurrentUserService user,
    DocumentMemoryCache cache,
    IMapper _mapper) : IRequestHandler<CreateDocumentCommand, DocumentDto>
{
    public async Task<DocumentDto> Handle(CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        var file = await files.AsAsyncRead()
            .SingleOrDefaultAsync(t => t.Id == command.FileId && t.UserId == user.Id, cancellationToken);

        if (file == null)
            throw new AccessDeniedException();

        var doc = await documents.AddAsync(command.Map(), cancellationToken);

        if (doc.GroupId == 0)
        {
            doc.GroupId = doc.Id;
            await documents.UpdateAsync(doc, cancellationToken);
        }

        cache.Clear();

        return _mapper.Map<DocumentDto>(doc);
    }
}