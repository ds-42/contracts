﻿namespace Contracts.Domain;

public class Org
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string ShortName { get; set; } = default!;
    public string ViewName { get; set; } = default!;
    public int? OwnershipId { get; set; }
    public string UNP { get; set; } = default!;
    public string OKPO { get; set; } = default!;
    public int AddressGroup { get; set; }
    public int? MailAddressId { get; set; }
    public int? JureAddressId { get; set; }
    public string Phone { get; set; } = default!;
    public string WWW { get; set; } = default!;
    public string EMail { get; set; } = default!;
    public int SertificateFileId { get; set; }
    public bool Verified { get; set; }

    public IEnumerable<Employee> Employees { get; set; } = default!;

    public Ownership? Ownership { get; set; }

    public Address? MailAddress { get; set; }
    public Address? JureAddress { get; set; }
}
