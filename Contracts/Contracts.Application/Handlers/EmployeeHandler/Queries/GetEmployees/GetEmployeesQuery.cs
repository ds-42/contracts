using AutoMapper;
using Contracts.Application.Cashes;
using Contracts.Application.Extensions;
using Contracts.Domain;
using Core.Application.Abstractions.Persistence.Repository.Read;
using Core.Application.BaseHandlers;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using Core.Auth.Application.Abstractions.Service;
using MediatR;
using System.Linq.Expressions;

namespace Contracts.Application.Handlers.EmployeeHandler.Queries.GetEmployees;

public class GetEmployeesQuery : BasePagination, IRequest<CountableList<EmployeeDto>>
{
    public int OrgId { get; set; }
}

