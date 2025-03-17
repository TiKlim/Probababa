using System;
using System.Collections.Generic;

namespace Wow.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string? Manufacturersname { get; set; }

    public DateOnly? Startupdate { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
