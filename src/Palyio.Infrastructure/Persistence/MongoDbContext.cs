using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Palyio.Domain.Entities;

namespace Palyio.Infrastructure.Persistence;

public record MongoDbSettings
{
    public required string ConnectionString { get; init; }
    public required string DatabaseName { get; init; }
}

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    static MongoDbContext()
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

        var conventions = new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new EnumRepresentationConvention(BsonType.String),
            new IgnoreExtraElementsConvention(true),
        };
        ConventionRegistry.Register("Palyio", conventions, _ => true);
    }

    public MongoDbContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        _database = client.GetDatabase(settings.DatabaseName);
    }

    public IMongoCollection<User> Users =>
        _database.GetCollection<User>("users");

    public IMongoCollection<Account> Accounts =>
        _database.GetCollection<Account>("accounts");

    public IMongoCollection<Transaction> Transactions =>
        _database.GetCollection<Transaction>("transactions");

    public IMongoCollection<LedgerEntry> LedgerEntries =>
        _database.GetCollection<LedgerEntry>("ledger_entries");
}
