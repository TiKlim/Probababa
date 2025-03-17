using System;
using System.Collections.Generic;

namespace Wow.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}