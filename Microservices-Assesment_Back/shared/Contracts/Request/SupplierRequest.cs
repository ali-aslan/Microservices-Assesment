using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Request;

public record SupplierRequest
{
    public Guid Id { get; set; }
}
