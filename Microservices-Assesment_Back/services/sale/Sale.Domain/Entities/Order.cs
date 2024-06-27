
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Sale.Domain.Entities;

public class Order: Entity<Guid>
{


    public Guid CustomerID { get; set; }
    public Guid ProductID { get; set; }
    public Guid SupplierID { get; set; }
    public Guid ShipperID { get; set; }
    public Guid SellerID { get; set; }

    public Order()
    {

    }

    public Order(Guid customerID, Guid productID, Guid supplierID, Guid shipperID, Guid sellerID)
    {
        CustomerID = customerID;
        ProductID = productID;
        SupplierID = supplierID;
        ShipperID = shipperID;
        SellerID = sellerID;
    }

    public virtual Customer Customer { get; set; }

    public virtual Product Product { get; set; }
}
