using MongoDB.Driver;
using Palyio.Application.Ports.Repositories;
using Palyio.Domain.Entities;

namespace Palyio.Infrastructure.Persistence.Repositories;

public class UserRepository(MongoDbContext context) : IUserRepository
{
    private readonly IMongoCollection<User> _collection = context.Users;

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task InsertAsync(User user)
    {
        await _collection.InsertOneAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
        await _collection.ReplaceOneAsync(filter, user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var filter = Builders<User>.Filter.Eq(u => u.Id, id);
        await _collection.DeleteOneAsync(filter);
    }
}
