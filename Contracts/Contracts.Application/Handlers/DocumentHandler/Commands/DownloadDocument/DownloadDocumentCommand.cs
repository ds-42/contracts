using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.DocumentHandler.Commands.DownloadDocument;

public class DownloadDocumentCommand : IRequest<DocumentInfo>
{
    public int Id { get; set; }
}


