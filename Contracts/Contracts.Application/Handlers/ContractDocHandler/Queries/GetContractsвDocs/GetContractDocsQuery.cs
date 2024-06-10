using Contracts.Application.Handlers.DocumentHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.ContractDocHandler.Queries.GetContractsвDocs;

public class GetContractDocsQuery : BasePagination, IRequest<CountableList<DocumentDto>>
{
    public int ContractId { get; set; }
}


