using Contracts.Domain.Enums;
using Core.Application.BaseRealizations;
using FluentValidation;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.EmployeeHandler;

public abstract class ContractValidator<T> : CustomValidator<T> 
{
    public IRuleBuilderOptions<T, string> RuleForNumber(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(20);
    }

    public IRuleBuilderOptions<T, DateOnly> RuleForRegistryDate(Expression<Func<T, DateOnly>> expression)
    {
        return RuleFor(expression).NotNull();
    }

    public IRuleBuilderOptions<T, DateOnly> RuleForStartDate(Expression<Func<T, DateOnly>> expression)
    {
        return RuleFor(expression).NotNull();
    }

    public IRuleBuilderOptions<T, decimal> RuleForPlannedPrice(Expression<Func<T, decimal>> expression)
    {
        return RuleFor(expression).GreaterThanOrEqualTo(0);
    }

    public IRuleBuilderOptions<T, string> RuleForDescription(Expression<Func<T, string>> expression)
    {
        return RuleFor(expression).NotEmpty().MaximumLength(500);
    }

}

