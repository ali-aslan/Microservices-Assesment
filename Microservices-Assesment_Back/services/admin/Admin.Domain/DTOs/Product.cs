using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.DTOs;

public record Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public Decimal Price { get; set; }
    public int StockQuantity { get; set; }
}
