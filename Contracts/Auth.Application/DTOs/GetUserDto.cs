using AutoMapper;
using Core.Application.Abstractions.Mappings;
using Core.Users.Domain;

namespace Auth.Application.DTOs;

public class GetUserDto : IMapFrom<User>
{
    public int UserId { get; set; }

    public string Login { get; set; } = default!;

    ///    public int[] Roles { get; set; } = default!;

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<User, GetUserDto>()
/*            .ForMember(e => e.Roles, r =>
                r.MapFrom(u => u.Roles.Select(s => s.ApplicationUserRoleId).ToArray()))*/;
    }
}