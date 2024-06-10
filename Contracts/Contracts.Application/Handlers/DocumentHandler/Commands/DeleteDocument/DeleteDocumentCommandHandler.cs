//using Contracts.Application.Cashes;
//using Contracts.Application.Extensions;
//using Contracts.Application.Handlers.FormatHandler.Commands.DeleteFormat;
//using Contracts.Domain;
//using Core.Application.Abstractions.Persistence.Repository.Writing;
//using Core.Auth.Application.Abstractions.Service;
//using MediatR;

//namespace Contracts.Application.Handlers.DocumentHandler.Commands.DeleteDocument;

//public class DeleteDocumentCommandHandler(
//    IBaseWriteRepository<Document> documents,
//    ICurrentUserService user,
//    DocumentMemoryCache cache) : IRequestHandler<DeleteDocumentCommand, bool>
//{
//    public async Task<bool> Handle(DeleteDocumentCommand command, CancellationToken cancellationToken)
//    {
//        var doc = await documents.GetItem(command.Id, cancellationToken);

//        await documents.RemoveAsync(doc, cancellationToken);

//        cache.Clear();

//        return true;
//    }
//}