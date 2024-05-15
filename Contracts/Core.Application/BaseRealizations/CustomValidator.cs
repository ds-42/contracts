using FluentValidation;
using System.Linq.Expressions;

namespace Core.Application.BaseRealizations;

internal sealed class BasePaginationFilterValidator : AbstractValidator<BasePagination>
{
    public BasePaginationFilterValidator()
    {
        RuleFor(r => r.Limit)
            .GreaterThan(0)
            .LessThanOrEqualTo(20)
            .When(r => r.Limit.HasValue);

        RuleFor(r => r.Offset)
            .GreaterThan(0)
            .When(r => r.Offset.HasValue);
    }
}

public abstract class CustomValidator<T> : AbstractValidator<T>
{
    public IRuleBuilderOptions<T, int> RuleForId(Expression<Func<T, int>> expression)
    {
        return RuleFor(expression)
            .NotNull()
            .GreaterThan(0);
    }

    public IRuleBuilderOptions<T, BasePagination> RuleForPagination(Expression<Func<T, BasePagination>> expression)
    {
        return RuleFor(expression)
            .NotNull()
            .SetValidator(new BasePaginationFilterValidator());
    }
}
