using Core.Application.BaseRealizations;
using Core.Application.DTOs;
using MediatR;

namespace Contracts.Application.Handlers.FormatHandler.Queries.GetFormats;

public class GetFormatsQuery : BasePagination, IRequest<CountableList<FormatExDto>>;

