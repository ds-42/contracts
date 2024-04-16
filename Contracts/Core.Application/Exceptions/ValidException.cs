using FluentValidation.Results;
using System.Net;

namespace Core.Application.Exceptions;

public class ValidException : BaseException
{
    public readonly List<ValidationFailure> errors;
    public ValidException(List<ValidationFailure> errors) : base(errors, HttpStatusCode.BadRequest)
    {
        this.errors = errors;
    }
}
