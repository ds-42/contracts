using Contracts.Application.Handlers.DocumentHandler;
using Core.Application.BaseRealizations;
using Core.Application.DTOs;

namespace Contracts.Application.Cashes;

public class DocumentMemoryCache : BaseCache<CountableList<DocumentDto>>;
