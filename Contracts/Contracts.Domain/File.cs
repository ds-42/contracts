using Core.Users.Domain;

namespace Contracts.Domain;

public class File
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FileName { get; set; } = default!;
    public DateTime Date { get; set; }
    public User User { get; set; } = default!;
}
