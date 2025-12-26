using System;
using System.Collections.Generic;

namespace KashCare.Logistics.Models;

public partial class City
{
    public int Cityid { get; set; }

    public int Countryid { get; set; }

    public string Name { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;
}
