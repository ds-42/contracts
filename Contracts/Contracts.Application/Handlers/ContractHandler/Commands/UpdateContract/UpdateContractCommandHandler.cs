using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Services;
using MediatR;

namespace Contracts.Application.Handlers.ContractHandler.Commands.UpdateContract;

public class UpdateContractCommandHandler(
    СontractorService contractor,
    ContractCache cache,
    IMapper _mapper) : IRequestHandler<UpdateContractCommand, ContractDto>
{
    public async Task<ContractDto> Handle(UpdateContractCommand command, CancellationToken cancellationToken)
    {
        await contractor.TestAccess(cancellationToken);

        var contract = await contractor.GetContractAsync(command.Id, cancellationToken);

        _mapper.Map(command, contract);

        await contractor.SaveContractAsync(contract, cancellationToken);

        cache.Clear();

        return _mapper.Map<ContractDto>(contract);
    }
}