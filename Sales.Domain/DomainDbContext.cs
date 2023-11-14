using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sales.Domain.Options;
using Sales.Domain.Sales;

namespace Sales.Domain
{
    public class DomainDbContext
    {
        private readonly IMongoDatabase _database;
        private readonly DBContextOptions _dBContextOptions;
        private readonly string saleCollection;

        public DomainDbContext(IOptions<DBContextOptions> dBContextOptions)
        {
            _dBContextOptions = dBContextOptions.Value;
            var mongoUrl = new MongoUrl(_dBContextOptions.ConnectionString);
            var mongoClientSettings = MongoClientSettings.FromUrl(mongoUrl);
            var client = new MongoClient(mongoClientSettings);

            _database = client.GetDatabase(_dBContextOptions.Database);
            saleCollection = _dBContextOptions.Collection;
        }

        public IMongoCollection<Sale> SaleCollection() => _database.GetCollection<Sale>(saleCollection);
    }
}
