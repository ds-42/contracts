using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.DocumentHandler.Queries.GetDocuments;

public class GetDocumentsQuery : BasePagination, IRequest<CountableList<DocumentDto>>
{
    public int GroupId { get; set; }
}

