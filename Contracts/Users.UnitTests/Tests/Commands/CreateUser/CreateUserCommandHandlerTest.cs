using AutoMapper;
using Core.Application.Abstractions;
using Core.Application.Abstractions.Persistence.Repository.Writing;
using Core.Application.Exceptions;
using Core.Auth.Application.Abstractions.Service;
using Core.Tests;
using Core.Tests.Attributes;
using Core.Tests.Fixtures;
using Core.Users.Domain;
using MediatR;
using Moq;
using System.Linq.Expressions;
using Users.Application.Cashes;
using Users.Application.DTOs;
using Users.Application.Handlers.Commands.CreateUser;
using Xunit.Abstractions;

namespace Users.UnitTests.Tests.Commands.CreateUser;

public class CreateUserCommandHandlerTest : RequestHandlerTestBase<CreateUserCommand, GetUserDto>
{
    private readonly Mock<IBaseWriteRepository<User>> _usersMok = new();

    private readonly Mock<ICurrentUserService> _currentServiceMok = new();

    private readonly Mock<ICacheService> _cacheServiceMok = new();

    private readonly UsersCache _usersCache;

    private readonly IMapper _mapper;

    public CreateUserCommandHandlerTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
        _mapper = new AutoMapperFixture(typeof(GetUserDto).Assembly).Mapper;
        _usersCache = new UsersCache(_cacheServiceMok.Object);
    }

    protected override IRequestHandler<CreateUserCommand, GetUserDto> CommandHandler =>
        new CreateUserCommandHandler(_usersMok.Object, _usersCache, _mapper);

    [Theory, FixtureInlineAutoData]
    public async Task Should_BeValid_When_CreateUser(CreateUserCommand command, int userId)
    {
        // arrange
        _currentServiceMok.SetupGet(p => p.Id).Returns(userId);
        _currentServiceMok.Setup(p => p.IsAdmin).Returns(true);

        User? user = null;
        _usersMok.Setup(
            p => p.AsAsyncRead()
                .SingleOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>(), default)
        ).ReturnsAsync(user);


        // act and assert
        await AssertNotThrow(command);
    }


    [Theory, FixtureInlineAutoData]
    public async Task Should_BeInvalid_When_CreateUser(CreateUserCommand command, int userId)
    {
        // arrange
        _currentServiceMok.SetupGet(p => p.Id).Returns(userId);
        _currentServiceMok.Setup(p => p.IsAdmin).Returns(true);

        var user = new User() 
        {
            Id = 1,
            Login = command.Login,
            Password = "1234567890",
            Role = Core.Users.Domain.Enums.ApplicationUserRolesEnum.Admin
        };

        _usersMok.Setup(
            p => p.AsAsyncRead()
                .SingleOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>(), default)
        ).ReturnsAsync(user);


        // act and assert
        await AssertThrow<BadRequestException>(command);
    }
}