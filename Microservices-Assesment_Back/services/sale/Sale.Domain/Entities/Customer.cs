
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Domain.Entities;

public class Customer:Entity<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public Customer()
    {
        Orders = new List<Order>();
    }

    public Customer(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }




}
