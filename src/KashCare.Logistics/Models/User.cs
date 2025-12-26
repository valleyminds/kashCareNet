using System;
using System.Collections.Generic;

namespace KashCare.Logistics.Models;

public partial class User
{
    public int Userid { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string? Phone { get; set; }

    public bool? Isemailverified { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Lastloginat { get; set; }

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
