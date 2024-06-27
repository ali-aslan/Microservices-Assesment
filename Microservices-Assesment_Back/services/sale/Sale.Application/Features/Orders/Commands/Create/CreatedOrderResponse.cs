namespace Sale.Application.Features.Orders.Commands.Create
{
    public class CreatedOrderResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid ShipperID { get; set; }
        public Guid SellerID { get; set; }
    }
}