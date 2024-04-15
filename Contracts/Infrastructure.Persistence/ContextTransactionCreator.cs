using Core.Application.Abstractions.Persistence;

namespace Infrastructure.Persistence;

internal class ContextTransactionCreator : IContextTransactionCreator
{
    private readonly DatabaseContext _dbContext;

    public ContextTransactionCreator(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return new ContextTransaction(await _dbContext.Database.BeginTransactionAsync(cancellationToken));
    }
}