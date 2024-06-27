namespace Sale.Application.Features.Orders.Commands.Delete
{
    public class DeletedOrderResponse
    {
        public Guid CustomerID { get; set; }
        public Guid ProductID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid ShipperID { get; set; }
        public Guid SellerID { get; set; }
    }
}