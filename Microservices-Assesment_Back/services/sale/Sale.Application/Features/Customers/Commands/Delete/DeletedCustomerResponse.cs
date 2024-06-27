using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Application.Features.Customers.Commands.Delete
{
    public class DeletedCustomerResponse
    {
       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
