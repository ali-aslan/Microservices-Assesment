using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Orders.Queries.GetList;

public class GetListOrderListItemDto
{
    public Guid Id { get; set; }
    public Guid CustomerID { get; set; }
    public Guid ProductID { get; set; }
    public Guid SupplierID { get; set; }
    public Guid ShipperID { get; set; }
    public Guid SellerID { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
