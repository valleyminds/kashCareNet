using System;
using System.Collections.Generic;

namespace KashCare.Logistics.Models;

public partial class Role
{
    public int Roleid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
