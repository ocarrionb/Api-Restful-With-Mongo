using MongoDB.Bson;
using MongoDB.Driver;
using Sales.Domain;
using Sales.Domain.Sales;

namespace Sales.Repository.Sales
{
    public sealed class SaleRepository : ISaleRepository
    {
        private readonly DomainDbContext _domainDbContext;
        public SaleRepository(DomainDbContext domainDbContext)
        {
            _domainDbContext = domainDbContext;
        }

        public async Task<IEnumerable<Sale>> GetAllSales()
        {
            return await _domainDbContext.SaleCollection().FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Sale> GetSaleById(string id)
        {
            var filter = Builders<Sale>.Filter.Eq(sale => sale.Id, new ObjectId(id));
            return await _domainDbContext.SaleCollection().Find(filter).FirstAsync();
        }

        public async Task InsertSale(Sale request)
        {
            await _domainDbContext.SaleCollection().InsertOneAsync(request);
        }

        public async Task UpdateSale(Sale request)
        {
            var  filter = Builders<Sale>.Filter.Eq( s => s.Id, request.Id);
            await _domainDbContext.SaleCollection().ReplaceOneAsync(filter, request);
        }
    }
}
