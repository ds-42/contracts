using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.EmployeeHandler;

public abstract class OrgValidator<T> : CustomValidator<T>
{
    public IRuleBuilderOptions<T, string> RuleForName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(300);
    }

    public IRuleBuilderOptions<T, string> RuleForShortName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(100);
    }

    public IRuleBuilderOptions<T, string> RuleForViewName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(50);
    }
}

