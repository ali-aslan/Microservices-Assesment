using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Suppliers.Commands.Create
{
    public class CreatedSupplierResponse
    {
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
    }
}
