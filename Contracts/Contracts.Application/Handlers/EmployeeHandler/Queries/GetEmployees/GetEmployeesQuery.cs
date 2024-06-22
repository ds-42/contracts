using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class GetEmployeesQuery : BasePagination, IRequest<CountableList<EmployeeDto>>;
