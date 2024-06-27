using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealer.Domain.Entities;

public class Shipper:Entity<Guid>
{
    public  string Name { get; set; }
    public  string Phone { get; set; }

    public Shipper()
    {
            
    }
    public Shipper(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }
    
}
