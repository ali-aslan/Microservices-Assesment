using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Domain.Entities
{
    public class Supplier:Entity<Guid>
    {

        public string Name { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }

        public Supplier()
        {
            
        }

        public Supplier(string name, string contactName, string phone)
        {
            Name = name;
            ContactName = contactName;
            Phone = phone;
        }

    }
}
