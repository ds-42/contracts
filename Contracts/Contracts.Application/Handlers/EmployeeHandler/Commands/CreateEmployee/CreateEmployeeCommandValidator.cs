using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Application.Handlers.EmployeeHandler.Commands.CreateEmployee;

public class CreateEmployeeCommandValidator : EmployeeValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleForId(e => e.OrgId);
        RuleForId(e => e.UserId);
    }
}