using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.FormatTypeHandler;

public abstract class FormatTypeValidator<T> : CustomValidator<T>
{
    public IRuleBuilderOptions<T, string> RuleForName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(200);
    }
}

