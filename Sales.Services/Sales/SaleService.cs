using Sales.Domain.Sales;
using Sales.Repository.Sales;

namespace Sales.Services.Sales
{
    public sealed class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public async Task<IEnumerable<Sale>> GetAllSales()
            => await _saleRepository.GetAllSales();
        
        public async Task<Sale> GetSaleById(string id)
            => await _saleRepository.GetSaleById(id);

        public async Task InsertSale(Sale request)
            => await _saleRepository.InsertSale(request);

        public async Task UpdateSale(Sale request)
            =>  await _saleRepository.UpdateSale(request);
    }
}
