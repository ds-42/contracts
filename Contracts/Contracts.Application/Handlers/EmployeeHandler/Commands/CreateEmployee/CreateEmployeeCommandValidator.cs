using FluentValidation;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : EmployeeValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleForId(t => t.UserId);
        RuleForSurname(t => t.Surname);
        RuleForName(t => t.Name);
        RuleForPatronymic(t => t.Patronymic);
        RuleForPostName(t => t.PostName);
        RuleForOperating(t => t.Operating);
        RuleForPhoneWork(t => t.PhoneWork);
        RuleForPhoneMobile(t => t.PhoneMobile);
        RuleForWWW(t => t.WWW);
        RuleForEMail(t => t.EMail);
        RuleFor(t => t.Role).IsInEnum();
    }
}