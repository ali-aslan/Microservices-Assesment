using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Application.Features.Suppliers.Queries.GetByList
{
    public class GetListSupplierListItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ContactName { get; set; }
    }
}
