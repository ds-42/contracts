using AutoMapper;
using Core.Application.Abstractions.Mappings;
using Core.Users.Domain;
using Core.Users.Domain.Enums;

namespace Users.Application.DTOs;

public class GetUserDto : IMapFrom<User>
{
    public int Id { get; set; }

    public string Login { get; set; } = default!;

    public UserRole Role { get; set; } = default!;

    public void CreateMap(Profile profile)
    {
        profile.CreateMap<User, GetUserDto>();
    }
}