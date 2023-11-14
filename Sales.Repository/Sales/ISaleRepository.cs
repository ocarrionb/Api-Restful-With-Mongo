using Sales.Domain;
using Sales.Domain.Sales;

namespace Sales.Repository.Sales
{
    public interface ISaleRepository
    {
        Task InsertSale(Sale request);
        Task UpdateSale(Sale request);
        Task<IEnumerable<Sale>> GetAllSales();
        Task<Sale> GetSaleById(string id);
    }
}
