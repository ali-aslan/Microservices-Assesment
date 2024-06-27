using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Request;

public record ShipperRequest
{
    public Guid Id { get; set; }
}
