using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record OrderResponse
{
    public Guid Id { get; set; }
    public CustomerResponse Customer { get; set; }
    public ProductResponse Product { get; set; }
    public Guid SupplierID { get; set; }
    public Guid ShipperID { get; set; }
    public Guid SellerID { get; set; }


}
