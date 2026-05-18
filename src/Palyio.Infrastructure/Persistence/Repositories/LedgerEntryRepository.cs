using MongoDB.Driver;
using Palyio.Application.Ports.Repositories;
using Palyio.Domain.Entities;

namespace Palyio.Infrastructure.Persistence.Repositories;

public class LedgerEntryRepository(MongoDbContext context) : ILedgerEntryRepository
{
    private readonly IMongoCollection<LedgerEntry> _collection = context.LedgerEntries;

    public async Task<IEnumerable<LedgerEntry>> GetByAccountIdAsync(Guid accountId)
    {
        var filter = Builders<LedgerEntry>.Filter.Eq(e => e.AccountId, accountId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<LedgerEntry>> GetByTransactionIdAsync(Guid transactionId)
    {
        var filter = Builders<LedgerEntry>.Filter.Eq(e => e.TransactionId, transactionId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task InsertAsync(LedgerEntry entry)
    {
        await _collection.InsertOneAsync(entry);
    }
}
