using MongoDB.Driver;
using Palyio.Application.Ports.Repositories;
using Palyio.Domain.Entities;

namespace Palyio.Infrastructure.Persistence.Repositories;

public class TransactionRepository(MongoDbContext context) : ITransactionRepository
{
    private readonly IMongoCollection<Transaction> _collection = context.Transactions;

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        var filter = Builders<Transaction>.Filter.Eq(t => t.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
    {
        var filter = Builders<Transaction>.Filter.Or(
            Builders<Transaction>.Filter.Eq(t => t.FromAccountId, accountId),
            Builders<Transaction>.Filter.Eq(t => t.ToAccountId, accountId)
        );
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task InsertAsync(Transaction transaction)
    {
        await _collection.InsertOneAsync(transaction);
    }
}
