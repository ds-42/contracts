using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Application.Handlers.AddressHandler;
using Contracts.Application.Handlers.AddressHandler.Commands.CreateAddress;
using Contracts.Application.Handlers.AddressHandler.Commands.DeleteAddress;
using Contracts.Application.Handlers.AddressHandler.Commands.UpdateAddress;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Writing;

namespace Contracts.Application.Services;

public class AddressService(
    IBaseWriteRepository<Address> addresses,
    AddressMemoryCache cache,
    IMapper _mapper)
{

    public async Task<AddressDto> CreateAddressAsync(CreateAddressCommand command, CancellationToken cancellationToken)
    {
        var addr = await addresses.AddAsync(command.Map(), cancellationToken);

        if (addr.GroupId == 0)
        {
            addr.GroupId = addr.Id;
            await addresses.UpdateAsync(addr, cancellationToken);
            command.Group = addr.Id;
        }

        cache.Clear();

        return _mapper.Map<AddressDto>(addr);
    }

    public async Task<AddressDto> UpdateAddressAsync(UpdateAddressCommand command, CancellationToken cancellationToken)
    {
        var addr = await addresses.GetItem(command.Group, command.Id, cancellationToken);

        _mapper.Map(command, addr);

        await addresses.UpdateAsync(addr, cancellationToken);

        cache.Clear();

        return _mapper.Map<AddressDto>(addr);
    }


    public async Task<bool> DeleteAddressAsync(DeleteAddressCommand command, CancellationToken cancellationToken)
    {
        var doc = await addresses.GetItem(command.Group, command.Id, cancellationToken);

        await addresses.RemoveAsync(doc, cancellationToken);

        cache.Clear();

        return true;
    }

}
