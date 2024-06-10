using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.DocumentHandler;

public abstract class DocumentValidator<T> : CustomValidator<T>
{
    public IRuleBuilderOptions<T, string> RuleForNumber(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).MaximumLength(20);
    }

    public IRuleBuilderOptions<T, string> RuleForTitle(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(200);
    }
}

