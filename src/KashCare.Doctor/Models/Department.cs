using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Department
{
    public int Departmentid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
