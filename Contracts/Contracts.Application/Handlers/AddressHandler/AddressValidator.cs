using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.AddressHandler;

public abstract class AddressValidator<T> : CustomValidator<T>
{
    public IRuleBuilderOptions<T, string> RuleForNote(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).MaximumLength(250);
    }
}

