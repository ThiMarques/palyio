using MongoDB.Driver;
using Palyio.Application.Ports.Repositories;
using Palyio.Domain.Entities;

namespace Palyio.Infrastructure.Persistence.Repositories;

public class AccountRepository(MongoDbContext context) : IAccountRepository
{
    private readonly IMongoCollection<Account> _collection = context.Accounts;

    public async Task<Account?> GetByIdAsync(Guid id)
    {
        var filter = Builders<Account>.Filter.Eq(a => a.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Account>> GetByUserIdAsync(Guid userId)
    {
        var filter = Builders<Account>.Filter.Eq(a => a.UserId, userId);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Account>> GetAllAccountsAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task InsertAsync(Account account)
    {
        await _collection.InsertOneAsync(account);
    }

    public async Task UpdateAsync(Account account)
    {
        var filter = Builders<Account>.Filter.Eq(a => a.Id, account.Id);
        await _collection.ReplaceOneAsync(filter, account);
    }

    public async Task DeleteAsync(Guid id)
    {
        var filter = Builders<Account>.Filter.Eq(a => a.Id, id);
        await _collection.DeleteOneAsync(filter);
    }
}
