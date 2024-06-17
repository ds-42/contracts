using Contracts.Domain;
using MediatR;

namespace Contracts.Application.Handlers.OrgHandler.Commands.CreateOrg;

public class CreateOrgCommand : IRequest<OrgDto>
{
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string ViewName { get; set; } = default!;
    public int? OwnershipId { get; set; }
    public string UNP { get; set; } = default!;
    public string OKPO { get; set; } = default!;

    public Org Map() => new()
    {
        Id = 0,
        Name = Name,
        ShortName = ShortName,
        ViewName = ViewName,
        OwnershipId = OwnershipId,
        AddressGroup = 0,
        UNP = UNP,
        OKPO = OKPO,
        MailAddressId = null,
        JureAddressId = null,
        Phone = "",
        WWW = "",
        EMail = "",
        SertificateFileId = 0,
        Verified = false,
    };
}

