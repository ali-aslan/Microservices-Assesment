using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Suppliers.Queries.GetById;

public class GetByIdSupplierResponse
{
    public string Name { get; set; }
    public string Phone { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
