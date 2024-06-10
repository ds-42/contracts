using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.OwnershipHandler;

public abstract class OwnershipValidator<T> : CustomValidator<T>
{
    public IRuleBuilderOptions<T, string> RuleForName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(200);
    }
    public IRuleBuilderOptions<T, string> RuleForShortName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(50);
    }
}

