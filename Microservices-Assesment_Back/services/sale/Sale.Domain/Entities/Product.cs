
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Repositories;

namespace Sale.Domain.Entities;

public class Product:Entity<Guid>
{
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public Decimal Price { get; set; }  
    public int StockQuantity { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public Product()
    {
        Orders = new List<Order>();
    }

    public Product(string name, string categoryName, decimal price, int stockQuantity)
    {
        Name = name;
        CategoryName = categoryName;
        Price = price;
        StockQuantity = stockQuantity;
    }
}
