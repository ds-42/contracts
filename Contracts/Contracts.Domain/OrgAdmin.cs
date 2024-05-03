using Core.Users.Domain;

namespace Contracts.Domain;

public class OrgAdmin
{
    public int Id { get; set; }
    public int OrgId { get; set; }
    public int UserId { get; set; }
    public Org? Org { get; set; }
    public User? User { get; set; }
}
