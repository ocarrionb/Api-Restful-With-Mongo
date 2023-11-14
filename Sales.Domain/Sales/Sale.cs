using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Sales.Domain.Sales
{
    public sealed class Sale
    {
        public ObjectId Id { get; set; }
        public int CustomerId { get; set; }
        public required string CustomerName { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int Amount { get; set; }
        public long UnitPrice { get; set; }
        public int Total { get; set; }
        public DateTime SaleDate { get; set; }
        public bool Active { get; set; }
    }
}
