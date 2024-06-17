using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.EmployeeHandler;

public abstract class EmployeeValidator<T> : CustomValidator<T>
{
    public IRuleBuilderOptions<T, string> RuleForSurname(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(50);
    }

    public IRuleBuilderOptions<T, string> RuleForName(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(50);
    }

    public IRuleBuilderOptions<T, string> RuleForPatronymic(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(50);
    }

    public IRuleBuilderOptions<T, string> RuleForPostName(Expression<Func<T, string?>> expression)
    {
        return RuleFor(expression).MaximumLength(200);
    }

    public IRuleBuilderOptions<T, string> RuleForOperating(Expression<Func<T, string?>> expression)
    {
        return RuleFor(expression).MaximumLength(100);
    }

    public IRuleBuilderOptions<T, string> RuleForPhoneWork(Expression<Func<T, string?>> expression)
    {
        return RuleFor(expression).MaximumLength(50);
    }

    public IRuleBuilderOptions<T, string> RuleForPhoneMobile(Expression<Func<T, string?>> expression)
    {
        return RuleFor(expression).MaximumLength(50);
    }
    public IRuleBuilderOptions<T, string> RuleForWWW(Expression<Func<T, string?>> expression)
    {
        return RuleFor(expression).MaximumLength(200);
    }

    public IRuleBuilderOptions<T, string> RuleForEMail(Expression<Func<T, string?>> expression)
    {
        return RuleFor(expression).MaximumLength(50);
    }
}

