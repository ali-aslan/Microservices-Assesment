using Admin.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.Features.EventBus;

public record GetOrderResponse
{
    public Guid Id { get; set; }
    public Customer Customer { get; set; }
    public Product Product { get; set; }
    public Supplier Supplier { get; set; }
    public Shipper Shipper { get; set; }
    public Seller Seller { get; set; }

}
