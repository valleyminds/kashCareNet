using System;
using System.Collections.Generic;

namespace KashCare.DoctorPatient.Models;

public partial class Doctorclinic
{
    public int Doctorid { get; set; }

    public int Clinicid { get; set; }

    public bool? Isprimary { get; set; }

    public decimal? Fee { get; set; }

    public virtual Clinic Clinic { get; set; } = null!;

    public virtual Doctor Doctor { get; set; } = null!;
}
