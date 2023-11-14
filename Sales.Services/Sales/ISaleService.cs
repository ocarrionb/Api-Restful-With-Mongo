using Sales.Domain.Sales;

namespace Sales.Services.Sales
{
    public interface ISaleService
    {
        Task InsertSale(Sale request);
        Task UpdateSale(Sale request);
        Task<IEnumerable<Sale>> GetAllSales();
        Task<Sale> GetSaleById(string id);
    }
}
