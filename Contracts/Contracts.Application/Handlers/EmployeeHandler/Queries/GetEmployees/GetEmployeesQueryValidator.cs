using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class GetEmployeesQueryValidator : EmployeeValidator<GetEmployeesQuery>
{
    public GetEmployeesQueryValidator()
    {
        RuleForPagination(t => t);
        RuleForId(t => t.OrgId);
    }
}
