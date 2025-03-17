using Avalonia.Media;
using System;
using System.Collections.Generic;

namespace Wow.Models;

public partial class ProductSale
{
    public int Id { get; set; }

    public DateOnly? Dateofsale { get; set; }

    public TimeOnly? Timeofsale { get; set; }

    public int? Product { get; set; }

    public int? Countofproduct { get; set; }

    public int? Man { get; set; }

    public SolidColorBrush color1 => Countofproduct == 100 ? new SolidColorBrush(Color.Parse("Red")) : color2;
    public SolidColorBrush color2 => Countofproduct == 50 ? new SolidColorBrush(Color.Parse("Orange")) : color3;
    public SolidColorBrush color3 => Countofproduct == 10  ? new SolidColorBrush(Color.Parse("Yellow")) : new SolidColorBrush(Color.Parse("White"));

    public virtual Manufacturer? ManNavigation { get; set; }

    public virtual Product? ProductNavigation { get; set; }
}
