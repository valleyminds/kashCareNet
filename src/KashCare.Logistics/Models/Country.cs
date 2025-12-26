using System;
using System.Collections.Generic;

namespace KashCare.Logistics.Models;

public partial class Country
{
    public int Countryid { get; set; }

    public string Name { get; set; } = null!;

    public string? Isocode { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
