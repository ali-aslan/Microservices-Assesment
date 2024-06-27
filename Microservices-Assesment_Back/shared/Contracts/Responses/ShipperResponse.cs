using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses;

public record ShipperResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
}
