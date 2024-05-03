using FluentValidation;
using System.Linq.Expressions;

namespace Core.Application.BaseRealizations;

public abstract class CustomValidator<T> : AbstractValidator<T>
{
    public IRuleBuilderOptions<T, int> RuleForId(Expression<Func<T, int>> expression)
    {
        return RuleFor(expression)
            .NotNull()
            .GreaterThan(0);
    }
}
