using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record SupplierResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ContactName { get; set; }
    public string Phone { get; set; }
}
