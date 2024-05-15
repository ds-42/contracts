using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.EmployeeHandler;

public abstract class CurrencyValidator<T> : CustomValidator<T> 
{
    public IRuleBuilderOptions<T, string> RuleForName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(50);
    }

    public IRuleBuilderOptions<T, string> RuleForShortName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(20);
    }

    public IRuleBuilderOptions<T, string> RuleForAbbrev(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(10);
    }
}

