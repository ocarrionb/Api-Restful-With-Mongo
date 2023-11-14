using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Sales.Domain.Options;

namespace Sales.Domain
{
    public class DomainDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _client;
        private readonly DBContextOptions _dBContextOptions;

        public DomainDbContext(DBContextOptions dBContextOptions)
        {
            _dBContextOptions = dBContextOptions;
            var mongoUrl = new MongoUrl(_dBContextOptions.ConnectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoUrl);
            var client = new MongoClient(mongoClientSettings);
            _database = client.GetDatabase(_dBContextOptions.Database);
        }
    }
}
