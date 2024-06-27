using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Request;

public record OrderRequest
{
    public Guid OrderId { get; set; }
}
