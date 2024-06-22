using Contracts.Application.Handlers.DocumentHandler;
using Core.Application.Abstractions;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class DocumentCache(ICacheService cache) :
    BaseCache<CountableList<DocumentDto>>(cache);


