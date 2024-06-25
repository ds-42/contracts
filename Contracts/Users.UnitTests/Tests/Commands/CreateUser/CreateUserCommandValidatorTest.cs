using AutoFixture;
using Core.Tests;
using FluentValidation;
using Users.Application.Features.User.Commands.CreateUser;
using Users.Application.Handlers.Commands.CreateUser;
using Xunit.Abstractions;

namespace Users.UnitTests.Tests.Commands.CreateUser;

public class CreateUserCommandValidatorTest : ValidatorTestBase<CreateUserCommand>
{
    public CreateUserCommandValidatorTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
    {
    }

    protected override IValidator<CreateUserCommand> TestValidator =>
        TestFixture.Create<CreateUserCommandValidator>();

    [Theory]
    [InlineData("admin", "admin")]
    public void Should_BeValid_When_RequestIsValid(string login, string password)
    {
        // arrange
        var query = new CreateUserCommand
        {
            Login = login,
            Password = password,
        };

        // act & assert
        AssertValid(query);
    }

    [Theory]
    [InlineData("", "password123")] // Empty login
    [InlineData("testuser", "")]    // Empty password
    [InlineData("123", "password123")] // Short login
    [InlineData("testuser", "123")]    // Short password
    [InlineData("toolonglogin123451234567890123456789012345678901234567890", "password123")] // Long login
    [InlineData("testuser", "toolongpassword123451234567890123456789012345678901234567890")] // Long password
    public void Should_NotValid_When_RequestIsInvalid(string login, string password)
    {
        // arrange
        var query = new CreateUserCommand
        {
            Login = login,
            Password = password,
        };

        // act & assert
        AssertNotValid(query);
    }
}